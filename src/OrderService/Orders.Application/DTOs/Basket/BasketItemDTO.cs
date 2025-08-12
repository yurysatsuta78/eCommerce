namespace Orders.Application.DTOs.Basket
{
    public record BasketItemDTO
    {
        public Guid ItemId { get; init; }
        public int Quantity { get; init; }
    }
}
