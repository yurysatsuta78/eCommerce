namespace Orders.Application.DTOs.Request
{
    public record CreateOrderItemRequest(
        Guid ItemId, 
        string Name, 
        int Quantity, 
        decimal Price);
}
