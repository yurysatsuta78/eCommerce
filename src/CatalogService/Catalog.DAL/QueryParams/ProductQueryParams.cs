using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.QueryParams
{
    public record ProductQueryParams : PaginationFilterParams
    {
        public string? Name { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public bool? InStockOnly { get; init; }
        public Guid? BrandId { get; init; }
        public Guid? CategoryId { get; init; }
    }
}
