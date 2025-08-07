using Catalog.BLL.Dto.Common;
using Catalog.BLL.Dto.Request.CatalogItem;
using Catalog.BLL.Dto.Response.CatalogItem;
using AddStockRequest = Catalog.BLL.Dto.Request.CatalogItem.AddStockDto;
using AddStockResponse = Catalog.BLL.Dto.Response.CatalogItem.AddStockDto;
using RemoveStockRequest = Catalog.BLL.Dto.Request.CatalogItem.RemoveStockDto;
using RemoveStockResponse = Catalog.BLL.Dto.Response.CatalogItem.RemoveStockDto;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICatalogItemService
    {
        Task<PaginatedResponse<CatalogItemDto>> GetPaginatedAsync(GetFilteredCatalogItemsDto dto, CancellationToken cancellationToken);
        Task AddAsync(CreateCatalogItemDto dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateCatalogItemDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<AddStockResponse> AddStockAsync(Guid id, AddStockRequest dto, CancellationToken cancellationToken);
        Task<RemoveStockResponse> RemoveStockAsync(Guid id, RemoveStockRequest dto, CancellationToken cancellationToken);
    }
}
