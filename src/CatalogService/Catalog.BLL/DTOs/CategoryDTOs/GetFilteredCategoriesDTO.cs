namespace Catalog.BLL.DTOs.CategoryDTOs
{
    public record GetFilteredCategoriesDTO
    {
        public string? Name { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
