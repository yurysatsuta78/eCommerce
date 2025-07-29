using MessageBroker.Abstraction.Contracts;
using MessageBroker.RabbitMQ.Clients;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace MessageBroker.RabbitMQ.Factories
{
    public class RabbitMqFactory : IMessageBrokerFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggerFactory _loggerFactory;

        public RabbitMqFactory(
            IConnectionFactory connectionFactory,
            IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory)
        {
            _connectionFactory = connectionFactory;
            _serviceProvider = serviceProvider;
            _loggerFactory = loggerFactory;
        }

        public IMessageProducer CreateProducer()
        {
            return new RabbitMqProducer(_connectionFactory, _loggerFactory.CreateLogger<RabbitMqProducer>());
        }

        public IMessageConsumer CreateConsumer()
        {
            return new RabbitMqConsumer(_connectionFactory, _serviceProvider, _loggerFactory.CreateLogger<RabbitMqConsumer>());
        }
    }
}
