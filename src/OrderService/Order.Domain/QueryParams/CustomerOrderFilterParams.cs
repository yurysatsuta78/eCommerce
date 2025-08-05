using Order.Domain.Enums;

namespace Order.Domain.QueryParams
{
    public record CustomerOrderFilterParams
    {
        public Guid? CustomerId { get; init; }
        public CustomerOrderStatuses? Status { get; init; }
        public decimal? MinTotalPrice { get; init; }
        public decimal? MaxTotalPrice { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 20;
    }
}
