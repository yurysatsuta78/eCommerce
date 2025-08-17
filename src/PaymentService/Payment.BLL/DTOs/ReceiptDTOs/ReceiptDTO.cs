using Payment.DAL.Enums;

namespace Payment.BLL.DTOs.ReceiptDTOs
{
    public record ReceiptDTO
    {
        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Statuses Status { get; init; }
        public decimal TotalPrice { get; init; }
        DateTime CreatedAt { get; init; }
    }
}
