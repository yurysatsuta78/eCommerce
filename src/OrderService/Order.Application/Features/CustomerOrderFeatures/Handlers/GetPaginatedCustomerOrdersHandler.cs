using MediatR;
using Order.Application.Dto.Common;
using Order.Application.Features.CustomerOrderFeatures.Queries;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class GetPaginatedCustomerOrdersHandler : IRequestHandler<GetPaginatedCustomerOrdersQuery, PaginatedResponse>
    {
        public Task<PaginatedResponse> Handle(GetPaginatedCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
