namespace Catalog.BLL.Dto.Request.CatalogBrand
{
    public record GetFilteredBrandsDto(string? Name, int PageNumber, int PageSize);
}
