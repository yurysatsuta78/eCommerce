using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Response.CatalogCategory
{
    public record CatalogCategoryDto(Guid CategoryId, string Name) : IEntityDto;
}
