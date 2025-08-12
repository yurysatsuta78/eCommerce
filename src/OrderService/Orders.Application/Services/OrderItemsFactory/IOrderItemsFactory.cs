using Orders.Application.Services.StockAvailabilityService;
using Orders.Domain.Models;

namespace Orders.Application.Services.OrderItemsFactory
{
    public interface IOrderItemsFactory
    {
        IEnumerable<OrderItem> CreateItems(IEnumerable<ValidatedBasketItem> validatedItems);
    }
}
