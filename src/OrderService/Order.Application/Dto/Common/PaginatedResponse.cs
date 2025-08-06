using Order.Application.Dto.Response;

namespace Order.Application.Dto.Common
{
    public record PaginatedResponse
    {
        public IEnumerable<CustomerOrderDto> Items { get; init; }
        public int TotalItems { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public PaginatedResponse(IEnumerable<CustomerOrderDto> items, int totalItems, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
