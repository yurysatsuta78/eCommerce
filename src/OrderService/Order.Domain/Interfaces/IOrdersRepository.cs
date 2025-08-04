using Order.Domain.Models;
using Order.Domain.QueryParams;

namespace Order.Domain.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<CustomerOrder>> GetPaginatedAsync(CustomerOrderFilterParams filter, CancellationToken cancellationToken);
        Task<CustomerOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(CustomerOrder customerOrder, CancellationToken cancellationToken);
        Task UpdateAsync(CustomerOrder customerOrder, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
