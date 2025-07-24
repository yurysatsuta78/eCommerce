using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Responce.CatalogCategory
{
    public record CatalogCategoryDto(Guid CategoryId, string Name) : IEntityDto;
}
