using Catalog.DAL.QueryParams.Base;

namespace Catalog.DAL.QueryParams
{
    public record CategoryQueryParams : PaginationFilterParams
    {
        public string? Name { get; init; }
    }
}
