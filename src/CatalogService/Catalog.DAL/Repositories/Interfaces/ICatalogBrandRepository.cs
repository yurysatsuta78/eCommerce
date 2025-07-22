using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ICatalogBrandRepository : IFilteredRepository<CatalogBrandQueryParams, CatalogBrandDb>;
}
