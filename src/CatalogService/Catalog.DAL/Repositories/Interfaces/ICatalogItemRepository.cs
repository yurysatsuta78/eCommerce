using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ICatalogItemRepository : IFilteredRepository<CatalogItemQueryParams, CatalogItemDb>
    {
        Task<IEnumerable<CatalogItemDb>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
