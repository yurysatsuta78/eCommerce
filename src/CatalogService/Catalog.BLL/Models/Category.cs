using Catalog.BLL.Exceptions;

namespace Catalog.BLL.Models
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Category() { }

        private Category(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }

        public static Category Create(Guid id, string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CatalogDomainException("Name cannot be empty.");

            return new Category(id, name);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }
    }
}
