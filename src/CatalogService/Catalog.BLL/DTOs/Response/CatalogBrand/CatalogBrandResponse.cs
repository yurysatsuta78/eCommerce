using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.Response.CatalogBrand
{
    public record CatalogBrandResponse : IPaginatedEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
