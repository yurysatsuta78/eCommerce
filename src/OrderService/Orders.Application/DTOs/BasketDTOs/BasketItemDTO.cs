namespace Orders.Application.DTOs.BasketDTOs
{
    public record BasketItemDTO
    {
        public Guid ItemId { get; init; }
        public int Quantity { get; init; }
    }
}
