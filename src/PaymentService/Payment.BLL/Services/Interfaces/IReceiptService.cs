using Payment.BLL.DTOs.ReceiptDTOs;

namespace Payment.BLL.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<PaginatedReceipts> GetFilteredAsync(GetFilteredReceiptsDTO dto, CancellationToken cancellationToken);
        Task<ReceiptDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
