using Catalog.DAL.Models.Base;
using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IFilteredRepository<in TFilter, TEntity> : IRepository<TEntity>
        where TEntity : Entity
        where TFilter : FilterParams
    {
        public Task<IEnumerable<TEntity>> GetPaginatedAsync(TFilter filter, CancellationToken cancellationToken);
    }
}
