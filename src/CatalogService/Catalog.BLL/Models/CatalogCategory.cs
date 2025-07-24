namespace Catalog.BLL.Models
{
    public class CatalogCategory
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        private CatalogCategory(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public static CatalogCategory Create(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            return new CatalogCategory(name);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }
    }
}
