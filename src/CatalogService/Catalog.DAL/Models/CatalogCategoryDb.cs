using Catalog.DAL.Models.Base;

namespace Catalog.DAL.Models
{
    public class CatalogCategoryDb : Entity
    {
        public string Name { get; set; } = default!;
    }
}
