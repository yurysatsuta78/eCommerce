using Orders.Domain.Enums;

namespace Orders.Application.Dto.Request
{
    public record GetFilteredOrdersDto(
        Guid? CustomerId, 
        OrderStatuses? Status, 
        int PageNumber, 
        int PageSize);
}
