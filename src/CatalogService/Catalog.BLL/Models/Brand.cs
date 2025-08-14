using Catalog.BLL.Exceptions;

namespace Catalog.BLL.Models
{
    public class Brand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Brand() { }

        private Brand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Brand Create(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CatalogDomainException("Name cannot be empty.");

            return new Brand(id, name);
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return; }

            Name = name.Trim();
        }
    }
}
