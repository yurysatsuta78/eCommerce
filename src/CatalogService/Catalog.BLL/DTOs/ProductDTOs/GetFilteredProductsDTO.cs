namespace Catalog.BLL.DTOs.ProductDTOs
{
    public record GetFilteredProductsDTO
    {
        public string? Name { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public bool? InStockOnly { get; init; }
        public Guid? BrandId { get; init; }
        public Guid? CategoryId { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}