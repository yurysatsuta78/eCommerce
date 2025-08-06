using Order.Domain.Enums;

namespace Order.Application.Dto.Response
{
    public record CustomerOrderDto
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public CustomerOrderStatuses Status { get; init; }
        public decimal TotalPrice { get; init; }
        public List<OrderItemDto> OrderItems { get; init; }
    }
}
