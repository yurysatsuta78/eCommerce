using Catalog.BLL.DTOs.Request.CatalogItem;
using Catalog.BLL.DTOs.Response;
using Catalog.BLL.DTOs.Response.CatalogItem;
using AddStockRequest = Catalog.BLL.DTOs.Request.CatalogItem.AddStockRequest;
using AddStockResponse = Catalog.BLL.DTOs.Response.CatalogItem.AddStockResponse;
using RemoveStockRequest = Catalog.BLL.DTOs.Request.CatalogItem.RemoveStockRequest;
using RemoveStockResponse = Catalog.BLL.DTOs.Response.CatalogItem.RemoveStockResponse;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICatalogItemService
    {
        Task<PaginatedResponse<CatalogItemResponse>> GetFilteredAsync(GetFilteredCatalogItemsRequest filter, CancellationToken cancellationToken);
        Task AddAsync(CreateCatalogItemRequest data, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateCatalogItemRequest data, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<AddStockResponse> AddStockAsync(Guid id, AddStockRequest data, CancellationToken cancellationToken);
        Task<RemoveStockResponse> RemoveStockAsync(Guid id, RemoveStockRequest data, CancellationToken cancellationToken);
    }
}
