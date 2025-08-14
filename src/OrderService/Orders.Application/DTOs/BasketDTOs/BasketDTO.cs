namespace Orders.Application.DTOs.BasketDTOs
{
    public record BasketDTO
    {
        public Guid CustomerId { get; init; }
        public List<BasketItemDTO> BasketItems { get; init; } = new();
    }
}
