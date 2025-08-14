using MediatR;
using MessageBroker.Abstraction.Contracts;
using Orders.Application.Features.OrderFeatures.Commands;
using Orders.Application.Services.Interfaces;
using Orders.Application.Services.OrderItemsFactory;
using Orders.Application.Services.StockAvailabilityService;
using Orders.Domain.Interfaces;
using Orders.Domain.Models;
using Contracts.Messaging;
using Contracts.Messaging.Messages.Orders.OrderCreated;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsInfoService _productsInfoService;
        private readonly IStockAvailabilityService _stockAvailabilityService;
        private readonly IOrderItemsFactory _orderItemsFactory;
        private readonly IMessageBrokerFactory _messageBrokerFactory;

        public CreateOrderHandler(IOrdersRepository ordersRepository, IProductsInfoService productsInfoService,
            IStockAvailabilityService stockAvailabilityService, IOrderItemsFactory orderItemsFactory, 
            IMessageBrokerFactory messageBrokerFactory)
        {
            _ordersRepository = ordersRepository;
            _productsInfoService = productsInfoService;
            _stockAvailabilityService = stockAvailabilityService;
            _orderItemsFactory = orderItemsFactory;
            _messageBrokerFactory = messageBrokerFactory;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var basketItems = request.Basket.BasketItems;
            var basketItemsIds = basketItems.Select(i => i.ItemId);

            var catalogItems = await _productsInfoService.GetProductsByIds(basketItemsIds, cancellationToken);

            var validatedBasketItems = _stockAvailabilityService.CheckAvailability(basketItems, catalogItems);

            var orderItems = _orderItemsFactory.CreateItems(validatedBasketItems).ToList();
            var order = Order.Create(Guid.NewGuid(), request.Basket.CustomerId, orderItems);

            await _ordersRepository.AddAsync(order, cancellationToken);

            var producer = _messageBrokerFactory.CreateProducer();
            
            var message = new OrderCreated(
                order.Id, 
                order.CustomerId,
                order.OrderItems.Select(item => new StockReservationItem(item.ItemId, item.Quantity)).ToList(),
                order.TotalPrice
            );

            await producer.PublishAsync(
                message,
                MessagingConstants.OrdersExchange.Name,
                MessagingConstants.OrdersExchange.OrderCreatedRoutingKey
            );
        }
    }
}
