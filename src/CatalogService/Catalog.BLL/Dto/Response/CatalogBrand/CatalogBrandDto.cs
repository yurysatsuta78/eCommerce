using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Response.CatalogBrand
{
    public record CatalogBrandDto(Guid BrandId, string Name) : IEntityDto;
}
