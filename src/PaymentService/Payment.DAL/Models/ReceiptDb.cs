using Payment.DAL.Enums;

namespace Payment.DAL.Models
{
    public class ReceiptDb
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Statuses Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
