namespace Catalog.BLL.Models
{
    public class CatalogBrand
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        private CatalogBrand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public static CatalogBrand Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            return new CatalogBrand(name);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }
    }
}
