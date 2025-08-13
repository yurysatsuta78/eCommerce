using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Response.CatalogBrand
{
    public record CatalogBrandDto : IEntityDto 
    {
        public Guid BrandId { get; init; }
        public string Name { get; init; }
    }
}
