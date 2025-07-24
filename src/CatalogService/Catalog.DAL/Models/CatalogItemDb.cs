using Catalog.DAL.Models.Base;

namespace Catalog.DAL.Models
{
    public class CatalogItemDb : Entity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

        public Guid CatalogBrandId { get; set; }
        public Guid CatalogCategoryId { get; set; }
        public CatalogBrandDb? CatalogBrand { get; set; }
        public CatalogCategoryDb? CatalogCategory { get; set; }
    }
}
