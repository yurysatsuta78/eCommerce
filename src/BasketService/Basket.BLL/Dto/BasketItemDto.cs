namespace Basket.BLL.Dto
{
    public record BasketItemDto
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
    }
}
