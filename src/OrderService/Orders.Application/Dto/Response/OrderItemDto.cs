namespace Orders.Application.Dto.Response
{
    public record OrderItemDto
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; } = default!;
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
