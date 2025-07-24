namespace Catalog.BLL.Dto.Common
{
    public class PaginatedResponse<T> where T : IEntityDto
    {
        public IEnumerable<T> Items { get; init; }
        public int TotalItems { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public PaginatedResponse(IEnumerable<T> items, int totalItems, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
