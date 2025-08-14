namespace Catalog.BLL.DTOs.CategoryDTOs
{
    public record CreateCategoryDTO
    {
        public string Name { get; init; } = default!;
    }
}
