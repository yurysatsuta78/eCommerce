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

            var dataTask = _customerOrdersRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _customerOrdersRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var customerOrderDtos = _mapper.Map<IEnumerable<CustomerOrderDto>>(dataTask.Result);

            return new PaginatedResponse(customerOrderDtos, countTask.Result, queryParams.PageNumber, queryParams.PageSize);
        }
    }
}
