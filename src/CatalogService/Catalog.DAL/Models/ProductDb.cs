using Catalog.DAL.Models.Base;

namespace Catalog.DAL.Models
{
    public class ProductDb : Entity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int ReservedStock { get; set; }
        public int StockCapacity { get; set; }

        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public BrandDb? Brand { get; set; }
        public CategoryDb? Category { get; set; }
    }
}
