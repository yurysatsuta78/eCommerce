using Orders.Application.DTOs.Basket;
using Orders.Application.DTOs.Catalog;

namespace Orders.Application.Services.StockAvailabilityService
{
    public class StockAvailabilityService : IStockAvailabilityService
    {
        public IEnumerable<ValidatedBasketItem> CheckAvailability(IEnumerable<BasketItemDTO> basketItems, 
            IEnumerable<CatalogItemDTO> catalogItems)
        {
            var catalogDict = catalogItems.ToDictionary(ci => ci.Id);

            foreach (var basketItem in basketItems)
            {
                if (!catalogDict.TryGetValue(basketItem.ItemId, out var catalogItem))
                {
                    throw new InvalidOperationException($"Item {basketItem.ItemId} not found in catalog.");
                }

                if (catalogItem.AvailableStock < basketItem.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Insufficient stock for \"{catalogItem.Name}\". " +
                        $"Available: {catalogItem.AvailableStock}, " +
                        $"Required: {basketItem.Quantity}.");
                }

                yield return new ValidatedBasketItem(basketItem, catalogItem);
            }
        }
    }
}
