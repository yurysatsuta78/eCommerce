namespace Catalog.BLL.DTOs.Request.CatalogCategory
{
    public record GetFilteredCategoriesRequest(string? Name, int PageNumber, int PageSize);
}
