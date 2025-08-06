using Order.Domain.Models;
using Order.Domain.QueryParams;

namespace Order.Domain.Interfaces
{
    public interface ICustomerOrdersRepository
    {
        Task<IEnumerable<CustomerOrder>> GetFilteredAsync(CustomerOrderFilterParams filter, CancellationToken cancellationToken);
        Task<int> GetCountAsync(CustomerOrderFilterParams filter, CancellationToken cancellationToken);
        Task<CustomerOrder?> GetByIdAsync(Guid id, bool withIncludes, CancellationToken cancellationToken);
        Task AddAsync(CustomerOrder customerOrder, CancellationToken cancellationToken);
        void Update(CustomerOrder customerOrder);
        void Delete(CustomerOrder customerOrder);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
