using Orders.Domain.Enums;

namespace Orders.Application.Dto.Response
{
    public record OrderDto
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public OrderStatuses Status { get; init; }
        public decimal TotalPrice { get; init; }
        public List<OrderItemDto> OrderItems { get; init; } = new();
    }
}
