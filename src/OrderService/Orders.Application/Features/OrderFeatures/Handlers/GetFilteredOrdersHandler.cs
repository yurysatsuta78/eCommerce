using AutoMapper;
using MediatR;
using Orders.Application.DTOs.Response;
using Orders.Application.Features.OrderFeatures.Queries;
using Orders.Domain.Interfaces;
using Orders.Domain.QueryParams;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class GetFilteredOrdersHandler : IRequestHandler<GetFilteredOrdersQuery, PaginatedResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetFilteredOrdersHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse> Handle(GetFilteredOrdersQuery request, CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<OrderFilterParams>(request.Filter);

            var orders = await _ordersRepository.GetFilteredAsync(queryParams, cancellationToken);
            var ordersCount = await _ordersRepository.GetCountAsync(queryParams, cancellationToken);

            var ordersDtos = _mapper.Map<IEnumerable<OrderResponse>>(orders);

            return new PaginatedResponse(ordersDtos, ordersCount, queryParams.PageNumber, queryParams.PageSize);
        }
    }
}
