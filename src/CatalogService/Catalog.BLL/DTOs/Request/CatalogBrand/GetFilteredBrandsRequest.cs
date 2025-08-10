namespace Catalog.BLL.DTOs.Request.CatalogBrand
{
    public record GetFilteredBrandsRequest(string? Name, int PageNumber, int PageSize);
}
