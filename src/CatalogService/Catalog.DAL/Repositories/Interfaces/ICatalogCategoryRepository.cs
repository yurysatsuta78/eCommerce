using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ICatalogCategoryRepository : IFilteredRepository<CatalogCategoryQueryParams, CatalogCategoryDb>;
}
