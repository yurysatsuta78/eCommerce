namespace Catalog.DAL.Models
{
    internal class CatalogItemDb
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string PictureFileName { get; set; } = default!;
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public bool OnOrder { get; set; }
        public CatalogBrandDb CatalogBrand { get; set; } = default!;
        public CatalogCategoryDb CatalogCategory { get; set; } = default!;
    }
}
