using Catalog.BLL.DTOs.Common;

namespace Catalog.BLL.DTOs.CategoryDTOs
{
    public record CategoryDTO : IPaginatedEntity 
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
    }
}
