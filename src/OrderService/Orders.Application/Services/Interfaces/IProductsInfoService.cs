using Orders.Application.DTOs.CatalogDTOs;

namespace Orders.Application.Services.Interfaces
{
    public interface IProductsInfoService
    {
        Task<IEnumerable<ProductInfoDTO>> GetProductsByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}