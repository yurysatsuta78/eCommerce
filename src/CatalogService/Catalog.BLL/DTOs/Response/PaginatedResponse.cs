using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.Response
{
    public class PaginatedResponse<T> where T : IPaginatedEntity
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
