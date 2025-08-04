using Order.Domain.Enums;
using Order.Domain.Exceptions;

namespace Order.Domain.Models
{
    public class Order
    {
        private readonly List<OrderItem> _orderItems = new();

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public OrderStatuses Status { get; private set; }
        public decimal TotalPrice => OrderItems.Sum(x => x.TotalPrice);
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private Order() { }

        private Order(Guid id, Guid customerId, List<OrderItem> orderItems)
        {
            Id = id;
            CustomerId = customerId;
            Status = OrderStatuses.Pending;
            _orderItems = new List<OrderItem>(orderItems);
        }


        public static Order Create(Guid id, Guid customerId, List<OrderItem> orderItems) 
        {
            if (orderItems is null || !orderItems.Any())
                throw new OrderDomainException("Order must contain at least one item.");

            return new Order(id, customerId, orderItems);
        }


        public void SetPaid() => ChangeStatus(OrderStatuses.Paid);
        public void SetCancelled() => ChangeStatus(OrderStatuses.Cancelled);
        public void SetCompleted() => ChangeStatus(OrderStatuses.Completed);


        private void ChangeStatus(OrderStatuses newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
                throw new OrderDomainException($"Invalid status transition from {Status} to {newStatus}");

            Status = newStatus;
        }


        private bool IsValidTransition(OrderStatuses current, OrderStatuses next)
        {
            return current switch
            {
                OrderStatuses.Pending => next == OrderStatuses.Paid || next == OrderStatuses.Cancelled,
                OrderStatuses.Paid => next == OrderStatuses.Completed || next == OrderStatuses.Cancelled,
                OrderStatuses.Cancelled => false,
                OrderStatuses.Completed => false,
                _ => false,
            };
        }
    }
}
