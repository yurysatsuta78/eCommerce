using MessageBroker.Abstraction.Contracts;
using MessageBroker.RabbitMQ.Config;
using MessageBroker.RabbitMQ.Factories;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace MessageBroker.RabbitMQ.Extensions
{
    public static class RabbitMqServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqMessageBroker(this IServiceCollection services, Action<RabbitMqOptions> configureOptions) 
        {
            var options = new RabbitMqOptions();
            configureOptions(options);

            services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory
            {
                HostName = options.HostName,
                Port = options.Port,
                VirtualHost = options.VirtualHost,
                UserName = options.UserName,
                Password = options.Password,
                DispatchConsumersAsync = true
            });

            services.AddSingleton<IMessageBrokerFactory, RabbitMqFactory>();

            return services;
        }
    }
}
