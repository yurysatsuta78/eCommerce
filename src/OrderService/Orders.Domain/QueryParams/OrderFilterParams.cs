using Orders.Domain.Enums;

namespace Orders.Domain.QueryParams
{
    public record OrderFilterParams
    {
        public Guid? CustomerId { get; init; }
        public OrderStatuses? Status { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 20;
    }
}
