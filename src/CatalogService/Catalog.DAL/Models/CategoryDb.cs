using Catalog.DAL.Models.Base;

namespace Catalog.DAL.Models
{
    public class CategoryDb : Entity
    {
        public string Name { get; set; } = default!;
    }
}
