namespace Order.Application.Dto.Response
{
    public record OrderItemDto
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
