using Catalog.BLL.DTOs.Request.CatalogCategory;
using Catalog.BLL.DTOs.Response;
using Catalog.BLL.DTOs.Response.CatalogCategory;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICatalogCategoryService
    {
        Task<PaginatedResponse<CatalogCategoryResponse>> GetFilteredAsync(GetFilteredCategoriesRequest filter, CancellationToken cancellationToken);
        Task AddAsync(CreateCategoryRequest data, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateCategoryRequest data, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
