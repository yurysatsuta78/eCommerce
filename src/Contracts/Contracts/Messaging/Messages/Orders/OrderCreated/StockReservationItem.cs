namespace Contracts.Messaging.Messages.Orders.OrderCreated
{
    public record StockReservationItem(Guid ItemId, int Quantity);
}
