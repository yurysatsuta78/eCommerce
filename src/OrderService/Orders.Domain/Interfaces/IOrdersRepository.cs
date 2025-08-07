using Orders.Domain.Models;
using Orders.Domain.QueryParams;

namespace Orders.Domain.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetFilteredAsync(OrderFilterParams filter, CancellationToken cancellationToken);
        Task<int> GetCountAsync(OrderFilterParams filter, CancellationToken cancellationToken);
        Task<Order?> GetByIdAsync(Guid id, bool withIncludes, CancellationToken cancellationToken);
        Task AddAsync(Order customerOrder, CancellationToken cancellationToken);
        void Update(Order customerOrder);
        void Delete(Order customerOrder);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
