using Catalog.BLL.Dto.Common;

namespace Catalog.BLL.Dto.Response.CatalogItem
{
    public record CatalogItemDto : IEntityDto 
    {
        public Guid ItemId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int AvailableStock { get; init; }
    }
}
