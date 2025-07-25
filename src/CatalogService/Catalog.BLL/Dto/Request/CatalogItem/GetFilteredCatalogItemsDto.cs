namespace Catalog.BLL.Dto.Request.CatalogItem
{
    public record GetFilteredCatalogItemsDto(string? Name, decimal? MinPrice, decimal? MaxPrice, bool? InStockOnly, Guid? BrandId,
        Guid? CategoryId, int PageNumber, int PageSize);
}