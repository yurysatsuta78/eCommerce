using MediatR;
using Orders.Application.DTOs.OrderDTOs;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetFilteredOrdersQuery : IRequest<PaginatedOrders>
    {
        public GetFilteredOrdersDTO Dto { get; init; } = default!;
    }
}
