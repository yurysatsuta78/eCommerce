using Orders.Application.DTOs.Basket;
using Orders.Application.DTOs.Catalog;

namespace Orders.Application.Services.StockAvailabilityService
{
    public interface IStockAvailabilityService
    {
        IEnumerable<ValidatedBasketItem> CheckAvailability(
            IEnumerable<BasketItemDTO> basketItems, 
            IEnumerable<CatalogItemDTO> catalogItems);
    }
}
