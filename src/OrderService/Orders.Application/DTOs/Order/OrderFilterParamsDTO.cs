using Orders.Domain.Enums;

namespace Orders.Application.DTOs.Order
{
    public record OrderFilterParamsDTO(
        Guid? CustomerId, 
        OrderStatuses? Status, 
        int PageNumber, 
        int PageSize);
}
