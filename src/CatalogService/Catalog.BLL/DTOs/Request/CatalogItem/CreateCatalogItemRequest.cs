namespace Catalog.BLL.DTOs.Request.CatalogItem
{
    public record CreateCatalogItemRequest(string Name, string Description, decimal Price, int RestockThreshold, int MaxStockThreshold,
        Guid BrandId, Guid CategoryId);
}
