using Catalog.BLL.Dto.Common;
using Catalog.BLL.Dto.Request.CatalogBrand;
using Catalog.BLL.Dto.Response.CatalogBrand;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<PaginatedResponse<CatalogBrandDto>> GetPaginatedAsync(GetFilteredBrandsDto dto, CancellationToken cancellationToken);
        Task AddAsync(CreateBrandDto dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateBrandDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
