using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ICategoriesRepository : IFilteredRepository<CategoryQueryParams, CategoryDb>;
}
