using MediatR;
using Orders.Application.Dto.Common;
using Orders.Application.Dto.Request;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetFilteredOrdersQuery : IRequest<PaginatedResponse>
    {
        public GetFilteredOrdersDto Filter { get; init; } = default!;
    }
}
