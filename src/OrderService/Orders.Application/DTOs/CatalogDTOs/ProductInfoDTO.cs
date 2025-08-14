namespace Orders.Application.DTOs.CatalogDTOs
{
    public record ProductInfoDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
        public int AvailableStock { get; init; }
    }
}
