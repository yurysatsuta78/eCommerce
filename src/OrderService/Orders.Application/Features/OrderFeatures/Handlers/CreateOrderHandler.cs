using AutoMapper;
using MediatR;
using Orders.Application.Dto.Response;
using Orders.Application.Features.OrderFeatures.Commands;
using Orders.Domain.Interfaces;
using Orders.Domain.Models;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request.Dto);

            await _ordersRepository.AddAsync(order, cancellationToken);
            await _ordersRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderDto>(order);
        }
    }
}
