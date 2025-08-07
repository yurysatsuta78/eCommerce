namespace Basket.BLL.Dto
{
    public record CustomerBasketDto
    {
        public List<BasketItemDto> Items { get; init; } = new();
    }
}
