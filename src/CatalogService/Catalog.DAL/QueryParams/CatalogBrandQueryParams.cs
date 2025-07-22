using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.QueryParams
{
    public record CatalogBrandQueryParams : PaginationFilterParams
    {
        public string? Name { get; init; }
    }
}
