using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Response.CatalogItem
{
    public record CatalogItemDto(Guid ItemId, string Name, string Description, decimal Price, int AvailableStock) : IEntityDto;
}
