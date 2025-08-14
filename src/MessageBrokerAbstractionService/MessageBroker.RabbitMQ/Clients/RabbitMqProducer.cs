using System.Text;
using MessageBroker.Abstraction.Contracts;
using MessageBroker.Abstraction.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MessageBroker.RabbitMQ.Clients
{
    public class RabbitMqProducer : IMessageProducer, IDisposable
    {
        private readonly ILogger<RabbitMqProducer> _logger;
        private IConnection _connection;
        
        private bool _disposed;

        public RabbitMqProducer(IConnectionFactory connectionFactory, ILogger<RabbitMqProducer> logger) 
        {
            _connection = connectionFactory.CreateConnection();
            _logger = logger;
        }

        public Task PublishAsync<TMessage>(TMessage message, string exchange, string routingKey) where TMessage : IMessage
        {
            if (_disposed) 
            { 
                throw new ObjectDisposedException(nameof(RabbitMqProducer)); 
            }

            using var channel = _connection.CreateModel();

            channel.ExchangeDeclare(exchange, ExchangeType.Topic, durable: true);

            try
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange, routingKey, properties, body);

                _logger.LogInformation($"Published {typeof(TMessage).Name} to {exchange}/{routingKey}");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to publish to {exchange}/{routingKey}");
                throw new MessageBrokerException($"Failed to publish to {exchange}/{routingKey}", ex);
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            _connection.Close();
            _connection.Dispose();
        }
    }
}
