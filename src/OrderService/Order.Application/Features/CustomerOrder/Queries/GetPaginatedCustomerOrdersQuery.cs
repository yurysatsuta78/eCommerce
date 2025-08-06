using MediatR;
using Order.Application.Dto.Common;
using Order.Application.Dto.Request;

namespace Order.Application.Features.CustomerOrder.Queries
{
    public record GetPaginatedCustomerOrdersQuery : IRequest<PaginatedResponse>
    {
        public GetFilteredCustomerOrdersDto Filter { get; init; }
    }
}
