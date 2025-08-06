namespace Order.Application.Dto.Request
{
    public record CreateCustomerOrderDto(
        Guid CustomerId,
        List<CreateOrderItemDto> OrderItems);
}
