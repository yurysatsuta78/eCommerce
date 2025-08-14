using Catalog.BLL.Handlers;
using Contracts.Messaging;
using Contracts.Messaging.Messages.Orders.OrderCreated;
using MessageBroker.Abstraction.Contracts;
using Microsoft.Extensions.Hosting;

namespace Catalog.BLL.Services
{
    public class MessageBrokerSubscriptionService : IHostedService
    {
        private readonly IMessageBrokerFactory _messageBrokerFactory;

        public MessageBrokerSubscriptionService(IMessageBrokerFactory messageBrokerFactory)
        {
            _messageBrokerFactory = messageBrokerFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = _messageBrokerFactory.CreateConsumer();

            await consumer.SubscribeAsync<OrderCreated, OrderCreatedHandler>(
                MessagingConstants.OrdersExchange.Name,
                MessagingConstants.OrdersExchange.OrderCreatedRoutingKey,
                "orders_created_queue"
            );
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
