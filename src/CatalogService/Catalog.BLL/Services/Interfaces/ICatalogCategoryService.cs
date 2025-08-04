using Catalog.BLL.Dto.Common;
using Catalog.BLL.Dto.Request.CatalogCategory;
using Catalog.BLL.Dto.Response.CatalogCategory;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICatalogCategoryService
    {
        Task<PaginatedResponse<CatalogCategoryDto>> GetPaginatedAsync(GetFilteredCategoriesDto dto, CancellationToken cancellationToken);
        Task AddAsync(CreateCategoryDto dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateCategoryDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
