using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.ProductDTOs
{
    public record ProductDTO : IPaginatedEntity 
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public decimal Price { get; init; }
        public int AvailableStock { get; init; }
    }
}
