using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.QueryParams
{
    public record BrandQueryParams : PaginationFilterParams
    {
        public string? Name { get; init; }
    }
}
