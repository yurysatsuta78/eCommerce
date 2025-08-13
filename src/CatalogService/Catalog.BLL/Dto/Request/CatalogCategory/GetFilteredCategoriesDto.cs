namespace Catalog.BLL.Dto.Request.CatalogCategory
{
    public record GetFilteredCategoriesDto(string? Name, int PageNumber, int PageSize);
}
