using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.BrandDTOs
{
    public record BrandDTO : IPaginatedEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
    }
}
