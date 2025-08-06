using AutoMapper;
using MediatR;
using Order.Application.Dto.Common;
using Order.Application.Dto.Response;
using Order.Application.Features.CustomerOrderFeatures.Queries;
using Order.Domain.Interfaces;
using Order.Domain.QueryParams;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class GetFilteredCustomerOrdersHandler : IRequestHandler<GetFilteredCustomerOrdersQuery, PaginatedResponse>
    {
        private readonly ICustomerOrdersRepository _customerOrdersRepository;
        private readonly IMapper _mapper;

        public GetFilteredCustomerOrdersHandler(ICustomerOrdersRepository customerOrdersRepository, IMapper mapper)
        {
            _customerOrdersRepository = customerOrdersRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse> Handle(GetFilteredCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CustomerOrderFilterParams>(request.Filter);

            var customerOrders = await _customerOrdersRepository.GetFilteredAsync(queryParams, cancellationToken);
            var ordersCount = await _customerOrdersRepository.GetCountAsync(queryParams, cancellationToken);

            var customerOrderDtos = _mapper.Map<IEnumerable<CustomerOrderDto>>(customerOrders);

            return new PaginatedResponse(customerOrderDtos, ordersCount, queryParams.PageNumber, queryParams.PageSize);
        }
    }
}
