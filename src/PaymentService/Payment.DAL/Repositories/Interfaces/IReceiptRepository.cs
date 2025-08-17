using Payment.DAL.Models;
using Payment.DAL.QueryParams;

namespace Payment.DAL.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<ReceiptDb>> GetFilteredAsync(ReceiptQueryParams filter, CancellationToken cancellationToken);
        Task<ReceiptDb?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(ReceiptDb receipt, CancellationToken cancellationToken);
    }
}
