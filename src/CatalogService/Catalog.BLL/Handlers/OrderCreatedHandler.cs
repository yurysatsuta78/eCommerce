using Contracts.Messaging.Messages.Orders.OrderCreated;
using MessageBroker.Abstraction.Contracts;

namespace Catalog.BLL.Handlers
{
    public class OrderCreatedHandler : IMessageHandler<OrderCreated>
    {
        public Task HandleAsync(OrderCreated message)
        {
            Console.WriteLine(message);

            throw new NotImplementedException();
        }
    }
}
