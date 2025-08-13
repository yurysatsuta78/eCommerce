using Catalog.BLL.Exceptions;

namespace Catalog.BLL.Models
{
    public class CatalogItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int AvailableStock { get; private set; }
        public int RestockThreshold { get; private set; }
        public int MaxStockThreshold { get; private set; }
        public CatalogBrand CatalogBrand { get; private set; }
        public CatalogCategory CatalogCategory { get; private set; }

        private CatalogItem() { }

        private CatalogItem(Guid id, string name, string description, decimal price, int restockThreshold,
            int maxStockThreshold, CatalogBrand brand, CatalogCategory category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AvailableStock = 0;
            RestockThreshold = restockThreshold;
            MaxStockThreshold = maxStockThreshold;
            CatalogBrand = brand;
            CatalogCategory = category;
        }

        public static CatalogItem Create(
            Guid id,
            string name,
            string description,
            decimal price,
            int restockThreshold,
            int maxStockThreshold,
            CatalogBrand brand,
            CatalogCategory category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CatalogDomainException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new CatalogDomainException("Description cannot be empty.");

            if (price <= 0)
                throw new CatalogDomainException("Price cannot be negative.");

            if (restockThreshold < 0 || maxStockThreshold < 0)
                throw new CatalogDomainException("Thresholds must be non-negative.");

            if (restockThreshold > maxStockThreshold)
                throw new CatalogDomainException("Restock threshold cannot exceed max threshold.");

            return new CatalogItem(
                id,
                name.Trim(),
                description.Trim(),
                price,
                restockThreshold,
                maxStockThreshold,
                brand,
                category);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }

        public void ChangeDescription(string? description)
        {
            if (string.IsNullOrWhiteSpace(description)) { return; }

            Description = description.Trim();
        }

        public void ChangePrice(decimal? price)
        {
            if (price is null) { return; }

            if (price < 0) { throw new CatalogDomainException("Price cannot be negative."); }

            Price = price.Value;
        }

        public int RemoveStock(int quantityDesired)
        {
            if (AvailableStock == 0)
            {
                throw new CatalogDomainException($"Empty stock, product item {Name} is sold out.");
            }

            if (quantityDesired <= 0)
            {
                throw new CatalogDomainException("Item units desired should be greater than zero.");
            }

            int removed = Math.Min(quantityDesired, AvailableStock);
            AvailableStock -= removed;
            return removed;
        }

        public int AddStock(int quantity)
        {
            if (quantity <= 0)
            {
                throw new CatalogDomainException("Item units to add must be greater than zero.");
            }

            int spaceLeft = MaxStockThreshold - AvailableStock;

            if (spaceLeft <= 0)
            {
                return 0;
            }

            int toAdd = Math.Min(quantity, spaceLeft);
            AvailableStock += toAdd;
            return toAdd;
        }
    }
}
