using Orders.Domain.Enums;

namespace Orders.Application.DTOs.Order
{
    public record OrderDTO
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public OrderStatuses Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public decimal TotalPrice { get; init; }
        public List<OrderItemDTO> OrderItems { get; init; } = new();
    }
}
