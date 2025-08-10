using Catalog.BLL.DTOs.Request.CatalogBrand;
using Catalog.BLL.DTOs.Response;
using Catalog.BLL.DTOs.Response.CatalogBrand;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<PaginatedResponse<CatalogBrandResponse>> GetFilteredAsync(GetFilteredBrandsRequest filter, CancellationToken cancellationToken);
        Task AddAsync(CreateBrandRequest data, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateBrandRequest data, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
