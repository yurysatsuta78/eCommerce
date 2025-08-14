using System.Collections.Concurrent;
using System.Text;
using MessageBroker.Abstraction.Contracts;
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
        private readonly IConnection _connection;
        private readonly ConcurrentDictionary<string, IModel> _channels = new();
        private bool _disposed;

        public RabbitMqConsumer(IConnectionFactory connectionFactory, IServiceProvider serviceProvider, ILogger<RabbitMqConsumer> logger) 
        {
            _connection = connectionFactory.CreateConnection();
            _serviceProvider = serviceProvider;
            _logger = logger;
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
            _channels.TryAdd(queue, channel);

            channel.ExchangeDeclare(exchange, ExchangeType.Topic, durable: true);
            channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false);
            channel.QueueBind(queue, exchange, routingKey);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (_, ea) =>
            {
                using var scope = _serviceProvider.CreateScope();

                try
                {
                    var handler = scope.ServiceProvider.GetRequiredService<THandler>();

                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var message = JsonConvert.DeserializeObject<TMessage>(json)
                        ?? throw new JsonException($"Deserialized {typeof(TMessage).Name} message is null");

                    await handler.HandleAsync(message);
                    channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex) when (ex is InvalidOperationException || ex is KeyNotFoundException)
                {
                    _logger.LogError(ex, $"Handler {typeof(THandler).Name} is not registered in DI");
                    channel.BasicNack(ea.DeliveryTag, false, false);
                }
                catch (JsonException ex) 
                {
                    _logger.LogError(ex, $"Failed to deserialize message {typeof(THandler).Name}");
                    channel.BasicNack(ea.DeliveryTag, false, false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error while handling message {typeof(THandler).Name} in handler {typeof(THandler).Name}");
                    channel.BasicNack(ea.DeliveryTag, false, false);
                }
            };

            channel.BasicConsume(queue, false, consumer);
            _logger.LogInformation("Subscribed to {Queue}", queue);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            foreach (var channel in _channels.Values)
            {
                channel.Close();
                channel.Dispose();
            }

            _connection.Close();
            _connection.Dispose();
        }
    }
}
