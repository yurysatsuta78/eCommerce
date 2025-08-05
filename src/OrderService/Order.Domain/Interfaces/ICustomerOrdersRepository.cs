using Order.Domain.Models;
using Order.Domain.QueryParams;

namespace Order.Domain.Interfaces
{
    public interface ICustomerOrdersRepository
    {
        Task<IEnumerable<CustomerOrder>> GetPaginatedAsync(CustomerOrderFilterParams filter, CancellationToken cancellationToken);
        Task<CustomerOrder?> GetByIdAsync(Guid id, bool withIncludes, CancellationToken cancellationToken);
        Task AddAsync(CustomerOrder customerOrder, CancellationToken cancellationToken);
        void Update(CustomerOrder customerOrder);
        void Delete(CustomerOrder customerOrder);
    }
}
