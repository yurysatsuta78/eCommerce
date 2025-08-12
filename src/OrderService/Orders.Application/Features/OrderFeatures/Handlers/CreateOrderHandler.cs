using MediatR;
using Orders.Application.Features.OrderFeatures.Commands;
using Orders.Application.Services.Interfaces;
using Orders.Application.Services.OrderItemsFactory;
using Orders.Application.Services.StockAvailabilityService;
using Orders.Domain.Interfaces;
using Orders.Domain.Models;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICatalogItemsInfoService _catalogItemsInfoService;
        private readonly IStockAvailabilityService _stockAvailabilityService;
        private readonly IOrderItemsFactory _orderItemsFactory;

        public CreateOrderHandler(IOrdersRepository ordersRepository, ICatalogItemsInfoService catalogItemsInfoService,
            IStockAvailabilityService stockAvailabilityService, IOrderItemsFactory orderItemsFactory)
        {
            _ordersRepository = ordersRepository;
            _catalogItemsInfoService = catalogItemsInfoService;
            _stockAvailabilityService = stockAvailabilityService;
            _orderItemsFactory = orderItemsFactory;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var basketItems = request.Basket.BasketItems;
            var basketItemsIds = basketItems.Select(i => i.ItemId);

            var catalogItems = await _catalogItemsInfoService.GetCatalogItemsByIds(basketItemsIds, cancellationToken);

            var validatedBasketItems = _stockAvailabilityService.CheckAvailability(basketItems, catalogItems);
            var orderItems = _orderItemsFactory.CreateItems(validatedBasketItems).ToList();

            var order = Order.Create(Guid.NewGuid(), request.Basket.CustomerId, orderItems);
            await _ordersRepository.AddAsync(order, cancellationToken);
        }
    }
}
