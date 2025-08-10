namespace Orders.Application.DTOs.Request
{
    public record CreateOrderRequest(
        Guid CustomerId,
        List<CreateOrderItemRequest> OrderItems);
}
