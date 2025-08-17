using Payment.DAL.Enums;

namespace Payment.BLL.DTOs.ReceiptDTOs
{
    public record GetFilteredReceiptsDTO
    {
        public Guid? OrderId { get; set; }
        public Statuses? Status { get; set; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
