using MediatR;
using Orders.Application.DTOs;
using Orders.Application.DTOs.Order;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetFilteredOrdersQuery : IRequest<PaginatedItemsDTO>
    {
        public OrderFilterParamsDTO Filter { get; init; } = default!;
    }
}
