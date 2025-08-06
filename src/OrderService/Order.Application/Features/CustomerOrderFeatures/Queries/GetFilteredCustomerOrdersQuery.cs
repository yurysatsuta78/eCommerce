using MediatR;
using Order.Application.Dto.Common;
using Order.Application.Dto.Request;

namespace Order.Application.Features.CustomerOrderFeatures.Queries
{
    public record GetFilteredCustomerOrdersQuery : IRequest<PaginatedResponse>
    {
        public GetFilteredCustomerOrdersDto Filter { get; init; } = default!;
    }
}
