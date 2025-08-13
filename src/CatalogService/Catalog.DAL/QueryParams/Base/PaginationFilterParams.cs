namespace Catalog.DAL.QueryParams.Base
{
    public abstract record PaginationFilterParams : FilterParams
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 20;
    }
}
