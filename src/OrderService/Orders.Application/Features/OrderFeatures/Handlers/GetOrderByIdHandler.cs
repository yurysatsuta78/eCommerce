using AutoMapper;
using MediatR;
using Orders.Application.DTOs.Order;
using Orders.Application.Features.OrderFeatures.Queries;
using Orders.Domain.Exceptions;
using Orders.Domain.Interfaces;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id, true, cancellationToken)
                ?? throw new OrderNotFoundException($"Order with id: {request.Id} not found.");

            var orderDto = _mapper.Map<OrderDTO>(order);

            return orderDto;
        }
    }
}
