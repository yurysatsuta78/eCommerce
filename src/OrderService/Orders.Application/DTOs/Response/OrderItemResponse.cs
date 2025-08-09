namespace Orders.Application.DTOs.Response
{
    public record OrderItemResponse
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; } = default!;
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
