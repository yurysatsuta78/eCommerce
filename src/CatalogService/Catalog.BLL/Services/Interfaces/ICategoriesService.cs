using Catalog.BLL.DTOs.CategoryDTOs;
using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<PaginatedEntities<CategoryDTO>> GetFilteredAsync(GetFilteredCategoriesDTO dto, CancellationToken cancellationToken);
        Task AddAsync(CreateCategoryDTO dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateCategoryDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
