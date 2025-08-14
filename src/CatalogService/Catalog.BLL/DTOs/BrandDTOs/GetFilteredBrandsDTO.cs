namespace Catalog.BLL.DTOs.BrandDTOs
{
    public record GetFilteredBrandsDTO
    {
        public string? Name { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
