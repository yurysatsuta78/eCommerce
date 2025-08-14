using Catalog.BLL.DTOs.BrandDTOs;
using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.Services.Interfaces
{
    public interface IBrandsService
    {
        Task<PaginatedEntities<BrandDTO>> GetFilteredAsync(GetFilteredBrandsDTO dto, CancellationToken cancellationToken);
        Task AddAsync(CreateBrandDTO dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateBrandDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
