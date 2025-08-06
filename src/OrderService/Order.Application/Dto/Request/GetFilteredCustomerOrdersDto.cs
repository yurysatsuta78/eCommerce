using Order.Domain.Enums;

namespace Order.Application.Dto.Request
{
    public record GetFilteredCustomerOrdersDto(
        Guid? CustomerId, 
        CustomerOrderStatuses? Status, 
        decimal? MinTotalPrice, 
        decimal? MaxTotalPrice, 
        int PageNumber, 
        int PageSize);
}
