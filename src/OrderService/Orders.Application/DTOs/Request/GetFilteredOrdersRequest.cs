using Orders.Domain.Enums;

namespace Orders.Application.DTOs.Request
{
    public record GetFilteredOrdersRequest(
        Guid? CustomerId, 
        OrderStatuses? Status, 
        int PageNumber, 
        int PageSize);
}
