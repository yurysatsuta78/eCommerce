using Orders.Domain.Enums;

namespace Orders.Application.DTOs.OrderDTOs
{
    public record GetFilteredOrdersDTO
    {
        public Guid? CustomerId { get; init; }
        public OrderStatuses? Status { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
