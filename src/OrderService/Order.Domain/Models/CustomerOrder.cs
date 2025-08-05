using Order.Domain.Enums;
using Order.Domain.Exceptions;

namespace Order.Domain.Models
{
    public class CustomerOrder
    {
        private readonly List<OrderItem> _orderItems = new();

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public CustomerOrderStatuses Status { get; private set; }
        public decimal TotalPrice => OrderItems.Sum(x => x.TotalPrice);
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private CustomerOrder() { }

        private CustomerOrder(Guid id, Guid customerId, List<OrderItem> orderItems)
        {
            Id = id;
            CustomerId = customerId;
            Status = CustomerOrderStatuses.Pending;
            _orderItems = new List<OrderItem>(orderItems);
        }


        public static CustomerOrder Create(Guid id, Guid customerId, List<OrderItem> orderItems) 
        {
            if (orderItems is null || !orderItems.Any())
                throw new OrderDomainException("Order must contain at least one item.");

            return new CustomerOrder(id, customerId, orderItems);
        }


        public void SetPaid() => ChangeStatus(CustomerOrderStatuses.Paid);
        public void SetCancelled() => ChangeStatus(CustomerOrderStatuses.Cancelled);
        public void SetCompleted() => ChangeStatus(CustomerOrderStatuses.Completed);


        private void ChangeStatus(CustomerOrderStatuses newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
                throw new OrderDomainException($"Invalid status transition from {Status} to {newStatus}");

            Status = newStatus;
        }


        private bool IsValidTransition(CustomerOrderStatuses current, CustomerOrderStatuses next)
        {
            return current switch
            {
                CustomerOrderStatuses.Pending => next == CustomerOrderStatuses.Paid || next == CustomerOrderStatuses.Cancelled,
                CustomerOrderStatuses.Paid => next == CustomerOrderStatuses.Completed || next == CustomerOrderStatuses.Cancelled,
                CustomerOrderStatuses.Cancelled => false,
                CustomerOrderStatuses.Completed => false,
                _ => false,
            };
        }
    }
}
