using MediatR;
using Order.Application.Dto.Common;
using Order.Application.Features.CustomerOrder.Queries;

namespace Order.Application.Features.CustomerOrder.Handlers
{
    public class GetPaginatedCustomerOrdersHandler : IRequestHandler<GetPaginatedCustomerOrdersQuery, PaginatedResponse>
    {
        public Task<PaginatedResponse> Handle(GetPaginatedCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
