namespace Catalog.BLL.Models
{
    public class CatalogBrand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private CatalogBrand() { }

        private CatalogBrand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static CatalogBrand Create(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            return new CatalogBrand(id, name);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }
    }
}
