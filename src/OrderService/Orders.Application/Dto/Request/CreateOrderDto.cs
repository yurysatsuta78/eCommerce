namespace Orders.Application.Dto.Request
{
    public record CreateOrderDto(
        Guid CustomerId,
        List<CreateOrderItemDto> OrderItems);
}
