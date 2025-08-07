using System.Collections.Concurrent;
using System.Text;
using MessageBroker.Abstraction.Contracts;
using MessageBroker.Abstraction.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.RabbitMQ.Clients
{
    public class RabbitMqConsumer : IMessageConsumer, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RabbitMqConsumer> _logger;
        private IConnection _connection;

        private readonly ConcurrentDictionary<Guid, IModel> _consumerChannels = new();
        private bool _disposed;

        public RabbitMqConsumer(IConnectionFactory connectionFactory, IServiceProvider serviceProvider, ILogger<RabbitMqConsumer> logger) 
        {
            _connection = connectionFactory.CreateConnection();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task SubscribeAsync<TMessage, THandler>(string exchange, string routingKey, string queue)
            where TMessage : IMessage
            where THandler : IMessageHandler<TMessage>
        {
            if (_disposed) 
            { 
                throw new ObjectDisposedException(nameof(RabbitMqConsumer)); 
            }

            var channel = _connection.CreateModel();
            _consumerChannels.TryAdd(Guid.NewGuid(), channel);

            channel.ExchangeDeclare(
                exchange: exchange,
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false,
                arguments: null
            );
            channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false);
            channel.QueueBind(queue: queue, exchange: exchange, routingKey: routingKey);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (_, ea) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<THandler>();

                try
                {
                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var message = JsonConvert.DeserializeObject<TMessage>(json);

                    if (message == null)
                    {
                        _logger.LogError($"Failed to deserialize message to {typeof(TMessage).Name}");
                        channel.BasicNack(ea.DeliveryTag, false, false);
                        return;
                    }

                    await handler.HandleAsync(message);
                    channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error while processing {typeof(TMessage).Name} message");
                    channel.BasicNack(ea.DeliveryTag, false, false);
                    throw new MessageProcessingException($"Error while processing {typeof(TMessage).Name} message", ex);
                }
            };

            channel.BasicConsume(queue, false, consumer);

            _logger.LogInformation($"{nameof(RabbitMqConsumer)} subscribed to {typeof(TMessage).Name} on {queue}");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            foreach (var pair in _consumerChannels)
            {
                try
                {
                    pair.Value?.Close();
                    pair.Value?.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error disposing consumer channel {pair.Key}");
                }
            }

            try
            {
                _connection?.Close();
                _connection?.Dispose();
                _logger.LogInformation($"{nameof(RabbitMqConsumer)} disposed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error disposing connection in {nameof(RabbitMqConsumer)}");
            }
        }
    }
}
