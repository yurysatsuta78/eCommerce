namespace Catalog.BLL.DTOs.ProductDTOs
{
    public record CreateProductDTO
    {
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public decimal Price { get; init; }
        public int StockCapacity { get; init; }
        public Guid BrandId { get; init; }
        public Guid CategoryId { get; init; }
    }
}
