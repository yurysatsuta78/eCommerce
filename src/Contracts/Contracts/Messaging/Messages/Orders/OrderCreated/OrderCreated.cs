using MessageBroker.Abstraction.Events;

namespace Contracts.Messaging.Messages.Orders.OrderCreated
{
    public record OrderCreated(
        Guid OrderId,
        Guid CustomerId,
        List<StockReservationItem> StockReservationItems,
        decimal TotalPrice
    ) : IntegrationEvent;
}
