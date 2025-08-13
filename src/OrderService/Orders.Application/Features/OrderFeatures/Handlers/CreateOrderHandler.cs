using AutoMapper;
using MediatR;
using Orders.Application.DTOs.Response;
using Orders.Application.Features.OrderFeatures.Commands;
using Orders.Domain.Interfaces;
using Orders.Domain.Models;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItems = request.Data.OrderItems
                .Select(oi => OrderItem.Create(oi.ItemId, oi.Name, oi.Quantity, oi.Price))
                .ToList();
            var order = Order.Create(Guid.NewGuid(), request.Data.CustomerId, orderItems);

            await _ordersRepository.AddAsync(order, cancellationToken);

            return _mapper.Map<OrderResponse>(order);
        }
    }
}
