using Catalog.DAL.Models.Base;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
