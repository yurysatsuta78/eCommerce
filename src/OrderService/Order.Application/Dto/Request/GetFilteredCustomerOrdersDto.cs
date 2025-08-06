using Order.Domain.Enums;

namespace Order.Application.Dto.Request
{
    public record GetFilteredCustomerOrdersDto(
        Guid? CustomerId, 
        CustomerOrderStatuses? Status, 
        int PageNumber, 
        int PageSize);
}
