using Orders.Application.DTOs.BasketDTOs;
using Orders.Application.DTOs.CatalogDTOs;

namespace Orders.Application.Services.StockAvailabilityService
{
    public interface IStockAvailabilityService
    {
        IEnumerable<ValidatedBasketItem> CheckAvailability(
            IEnumerable<BasketItemDTO> basketItems, 
            IEnumerable<ProductInfoDTO> catalogItems);
    }
}
