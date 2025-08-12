using Orders.Application.DTOs.Basket;
using Orders.Application.DTOs.Catalog;

namespace Orders.Application.Services.StockAvailabilityService
{
    public record ValidatedBasketItem(BasketItemDTO BasketItem, CatalogItemDTO CatalogItem);
}
