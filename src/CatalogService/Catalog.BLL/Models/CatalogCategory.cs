namespace Catalog.BLL.Models
{
    public class CatalogCategory
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        private CatalogCategory() { }

        private CatalogCategory(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }

        public static CatalogCategory Create(Guid id, string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            return new CatalogCategory(id, name);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }
    }
}
