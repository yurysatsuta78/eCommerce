namespace Catalog.BLL.DTOs.Request.CatalogItem
{
    public record UpdateCatalogItemRequest(string? Name, string? Description, decimal? Price);
}
