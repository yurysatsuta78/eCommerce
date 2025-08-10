using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.Response.CatalogItem
{
    public record CatalogItemResponse : IPaginatedEntity 
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int AvailableStock { get; init; }
    }
}
