using Catalog.BLL.Exceptions;

namespace Catalog.BLL.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int InStock { get; private set; }
        public int ReservedStock { get; private set; }
        public int StockCapacity { get; private set; }
        public int AvailableStock => InStock - ReservedStock;
        public Brand Brand { get; private set; }
        public Category Category { get; private set; }

        private Product() { }

        private Product(Guid id, string name, string description, decimal price, int stockCapacity,
            Brand brand, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            InStock = 0;
            ReservedStock = 0;
            StockCapacity = stockCapacity;
            Brand = brand;
            Category = category;
        }

        public static Product Create(
            Guid id,
            string name,
            string description,
            decimal price,
            int stockCapacity,
            Brand brand,
            Category category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CatalogDomainException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new CatalogDomainException("Description cannot be empty.");

            if (price <= 0)
                throw new CatalogDomainException("Price cannot be negative.");

            if (stockCapacity <= 0)
                throw new CatalogDomainException("Stock capacity cannot be negative.");

            return new Product(
                id,
                name.Trim(),
                description.Trim(),
                price,
                stockCapacity,
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

        public void AddStock(int quantity)
        {
            if (quantity <= 0)
                throw new CatalogDomainException("Quantity to add must be greater than zero.");

            var capacityLeft = StockCapacity - InStock;

            if (quantity > capacityLeft)
                throw new CatalogDomainException($"Not enough capacity in stock. Capacity left: {capacityLeft}.");

            InStock += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity <= 0)
                throw new CatalogDomainException("Quantity to remove must be greater than zero.");

            if (quantity > AvailableStock)
                throw new CatalogDomainException($"Not enough available units in stock. Requested {quantity}, available {AvailableStock}.");

            InStock -= quantity;
        }

        public void AddReserved(int quantity)
        {
            if (quantity <= 0)
                throw new CatalogDomainException("Quantity to reserve must be greater than zero.");

            if (quantity > AvailableStock)
                throw new CatalogDomainException($"Not enough available units in stock. Requested {quantity}, available {AvailableStock}.");

            ReservedStock += quantity;
        }

        public void RemoveReserved(int quantity)
        {
            if (quantity <= 0)
                throw new CatalogDomainException("Quantity to remove from reserve must be greater than zero.");

            if (quantity > ReservedStock)
                throw new CatalogDomainException($"Not enough reserved units. Requested {quantity}, available {ReservedStock}.");

            ReservedStock -= quantity;
        }

        public void FinalizeStock(int quantity)
        {
            if (quantity <= 0)
                throw new CatalogDomainException("Quantity to finalize must be greater than zero.");

            if (quantity > ReservedStock)
                throw new CatalogDomainException($"Cannot finalize stock for item '{Name}'. Requested {quantity}, but only {ReservedStock} units are reserved.");

            ReservedStock -= quantity;
            InStock -= quantity;
        }
    }
}
