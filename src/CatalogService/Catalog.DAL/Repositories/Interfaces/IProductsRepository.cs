using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IProductsRepository : IFilteredRepository<ProductQueryParams, ProductDb>
    {
        Task<IEnumerable<ProductDb>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
