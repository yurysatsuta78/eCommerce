namespace Payment.BLL.DTOs.ReceiptDTOs
{
    public record PaginatedReceipts
    {
        public IEnumerable<ReceiptDTO> Items { get; init; }
        public long TotalItems { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public PaginatedReceipts(IEnumerable<ReceiptDTO> items, long totalItems, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
