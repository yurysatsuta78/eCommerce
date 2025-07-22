using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.QueryParams
{
    public record CatalogItemQueryParams : PaginationFilterParams
    {
        public string? Name { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public bool InStockOnly { get; init; } = false;
        public Guid? BrandId { get; init; }
        public Guid? CategoryId { get; init; }
    }
}
