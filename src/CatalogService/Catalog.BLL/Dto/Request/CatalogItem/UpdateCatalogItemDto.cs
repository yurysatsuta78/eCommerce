namespace Catalog.BLL.Dto.Request.CatalogItem
{
    public record UpdateCatalogItemDto(string? Name, string? Description, decimal? Price, Guid? BrandId, Guid? CategoryId);
}
