namespace Catalog.BLL.DTOs.Request.CatalogItem
{
    public record GetFilteredCatalogItemsRequest(string? Name, decimal? MinPrice, decimal? MaxPrice, bool? InStockOnly, Guid? BrandId,
        Guid? CategoryId, int PageNumber, int PageSize);
}