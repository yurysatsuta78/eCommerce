using Orders.Application.DTOs.BasketDTOs;
using Orders.Application.DTOs.CatalogDTOs;

namespace Orders.Application.Services.StockAvailabilityService
{
    public class StockAvailabilityService : IStockAvailabilityService
    {
        public IEnumerable<ValidatedBasketItem> CheckAvailability(IEnumerable<BasketItemDTO> basketItems, 
            IEnumerable<ProductInfoDTO> products)
        {
            var productsDict = products.ToDictionary(ci => ci.Id);

            foreach (var basketItem in basketItems)
            {
                if (!productsDict.TryGetValue(basketItem.ItemId, out var product))
                {
                    throw new InvalidOperationException($"Item {basketItem.ItemId} not found in catalog.");
                }

                if (product.AvailableStock < basketItem.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Insufficient stock for \"{product.Name}\". " +
                        $"Available: {product.AvailableStock}, " +
                        $"Required: {basketItem.Quantity}.");
                }

                yield return new ValidatedBasketItem(basketItem, product);
            }
        }
    }
}
