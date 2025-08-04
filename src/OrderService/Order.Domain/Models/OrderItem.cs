using Order.Domain.Exceptions;

namespace Order.Domain.Models
{
    public class OrderItem
    {
        public Guid ItemId { get; private set; }
        public string Name { get; private set; } = default!;
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice => Price * Quantity;

        private OrderItem() { }

        private OrderItem(Guid itemId, string name, int quantity, decimal price)
        {
            ItemId = itemId;
            Name = name;
            Quantity = quantity;
            Price = price;
        }


        public static OrderItem Create(Guid itemId, string name, int quantity, decimal price) 
        {
            if (string.IsNullOrEmpty(name))
                throw new OrderDomainException("Name cannot be empty.");

            if (quantity <= 0)
                throw new OrderDomainException("Quantity must be greater than zero.");

            if (price <= 0)
                throw new OrderDomainException("Price must be greater than zero.");

            return new OrderItem(itemId, name, quantity, price);
        }
    }
}
