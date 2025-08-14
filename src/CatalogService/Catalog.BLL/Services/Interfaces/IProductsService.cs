using Catalog.BLL.DTOs.Common;
using Catalog.BLL.DTOs.ProductDTOs;
using Catalog.BLL.DTOs.ProductDTOs.Stock;

namespace Catalog.BLL.Services.Interfaces
{
    public interface IProductsService
    {
        Task<PaginatedEntities<ProductDTO>> GetFilteredAsync(GetFilteredProductsDTO dto, CancellationToken cancellationToken);
        Task AddAsync(CreateProductDTO dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, UpdateProductDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task AddStockAsync(Guid id, AddStockDTO dto, CancellationToken cancellationToken);
        Task RemoveStockAsync(Guid id, RemoveStockDTO dto, CancellationToken cancellationToken);
    }
}
