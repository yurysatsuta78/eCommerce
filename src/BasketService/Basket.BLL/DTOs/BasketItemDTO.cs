namespace Basket.BLL.DTOs
{
    public record BasketItemDTO
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
    }
}
