namespace Order.Application.Dto.Request
{
    public record CreateOrderItemDto(
        Guid ItemId, 
        string Name, 
        int Quantity, 
        decimal Price);
}
