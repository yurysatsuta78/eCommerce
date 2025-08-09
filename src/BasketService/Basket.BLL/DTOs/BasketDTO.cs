namespace Basket.BLL.DTOs
{
    public record BasketDTO
    {
        public List<BasketItemDTO> BasketItems { get; init; } = new();
    }
}
