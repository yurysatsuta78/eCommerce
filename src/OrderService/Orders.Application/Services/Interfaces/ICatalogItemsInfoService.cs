using Orders.Application.DTOs.Catalog;

namespace Orders.Application.Services.Interfaces
{
    public interface ICatalogItemsInfoService
    {
        Task<IEnumerable<CatalogItemDTO>> GetCatalogItemsByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}