using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.Response.CatalogCategory
{
    public record CatalogCategoryResponse : IPaginatedEntity 
    {
        public Guid Id { get; init; } 
        public string Name { get; init; }
    }
}
