namespace Catalog.BLL.Dto.Request.CatalogItem
{
    public record CreateCatalogItemDto(string Name, string Description, decimal Price, int RestockThreshold, int MaxStockThreshold,
        Guid BrandId, Guid CategoryId);
}
