namespace Catalog.BLL.DTOs.BrandDTOs
{
    public record CreateBrandDTO
    {
        public string Name { get; init; } = default!;
    }
}
