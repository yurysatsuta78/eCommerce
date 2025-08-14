using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IBrandsRepository : IFilteredRepository<BrandQueryParams, BrandDb>;
}
