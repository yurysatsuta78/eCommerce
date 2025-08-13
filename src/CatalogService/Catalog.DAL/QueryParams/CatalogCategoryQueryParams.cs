using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.QueryParams
{
    public record CatalogCategoryQueryParams : PaginationFilterParams
    {
        public string? Name { get; init; }
    }
}
