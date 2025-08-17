using Payment.DAL.Enums;

namespace Payment.DAL.QueryParams
{
    public record ReceiptQueryParams
    {
        public Guid? OrderId { get; set; }
        public Statuses? Status { get; set; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
