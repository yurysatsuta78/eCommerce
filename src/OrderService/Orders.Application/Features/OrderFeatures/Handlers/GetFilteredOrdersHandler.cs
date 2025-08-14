using AutoMapper;
using MediatR;
using Orders.Application.DTOs.OrderDTOs;
using Orders.Application.Features.OrderFeatures.Queries;
using Orders.Domain.Interfaces;
using Orders.Domain.QueryParams;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class GetFilteredOrdersHandler : IRequestHandler<GetFilteredOrdersQuery, PaginatedOrders>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetFilteredOrdersHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedOrders> Handle(GetFilteredOrdersQuery request, CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<OrderFilterParams>(request.Dto);

            var orders = await _ordersRepository.GetFilteredAsync(queryParams, cancellationToken);
            var ordersCount = await _ordersRepository.GetCountAsync(queryParams, cancellationToken);

            var orderDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);

            return new PaginatedOrders(orderDtos, ordersCount, queryParams.PageNumber, queryParams.PageSize);
        }
    }
}
