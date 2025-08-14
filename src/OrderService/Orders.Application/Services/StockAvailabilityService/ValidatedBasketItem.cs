using Orders.Application.DTOs.BasketDTOs;
using Orders.Application.DTOs.CatalogDTOs;

namespace Orders.Application.Services.StockAvailabilityService
{
    public record ValidatedBasketItem(BasketItemDTO BasketItem, ProductInfoDTO CatalogItem);
}
