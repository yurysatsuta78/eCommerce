namespace Orders.Application.DTOs.Catalog
{
    public record CatalogItemDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
        public int AvailableStock { get; init; }
    }
}
