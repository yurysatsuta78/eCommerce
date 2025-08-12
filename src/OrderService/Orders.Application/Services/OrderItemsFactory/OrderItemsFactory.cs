using Orders.Application.Services.StockAvailabilityService;
using Orders.Domain.Models;

namespace Orders.Application.Services.OrderItemsFactory
{
    public class OrderItemsFactory : IOrderItemsFactory
    {
        public IEnumerable<OrderItem> CreateItems(IEnumerable<ValidatedBasketItem> validatedItems)
        {
            foreach (var item in validatedItems)
            {
                yield return OrderItem.Create(
                    item.CatalogItem.Id,
                    item.CatalogItem.Name,
                    item.BasketItem.Quantity,
                    item.CatalogItem.Price);
            }
        }
    }
}
