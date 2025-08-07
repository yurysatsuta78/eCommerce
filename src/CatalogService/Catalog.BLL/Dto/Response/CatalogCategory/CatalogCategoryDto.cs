using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Response.CatalogCategory
{
    public record CatalogCategoryDto : IEntityDto 
    {
        public Guid CategoryId { get; init; } 
        public string Name { get; init; }
    }
}
