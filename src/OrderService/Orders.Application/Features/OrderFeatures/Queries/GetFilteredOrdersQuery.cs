using MediatR;
using Orders.Application.DTOs.Request;
using Orders.Application.DTOs.Response;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetFilteredOrdersQuery : IRequest<PaginatedResponse>
    {
        public GetFilteredOrdersRequest Filter { get; init; } = default!;
    }
}
