namespace Catalog.DAL.Models
{
    public class CatalogItemDb
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureFileName { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public bool OnOrder { get; set; }

        public Guid CatalogBrandId { get; set; }
        public Guid CatalogCategoryId { get; set; }
        public CatalogBrandDb? CatalogBrand { get; set; }
        public CatalogCategoryDb? CatalogCategory { get; set; }
    }
}
