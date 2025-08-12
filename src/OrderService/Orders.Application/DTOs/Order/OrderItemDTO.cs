namespace Orders.Application.DTOs.Order
{
    public record OrderItemDTO
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; } = default!;
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
