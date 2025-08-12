namespace Orders.Application.DTOs.Basket
{
    public record BasketDTO
    {
        public Guid CustomerId { get; init; }
        public List<BasketItemDTO> BasketItems { get; init; } = new();
    }
}
