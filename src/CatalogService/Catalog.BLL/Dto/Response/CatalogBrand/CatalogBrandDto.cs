using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Responce.CatalogBrand
{
    public record CatalogBrandDto(Guid BrandId, string Name) : IEntityDto;
}
