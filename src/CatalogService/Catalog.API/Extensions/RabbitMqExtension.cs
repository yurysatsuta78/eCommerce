using Catalog.BLL.Handlers;
using MessageBroker.RabbitMQ.Extensions;

namespace Catalog.API.Extensions
{
    public static class RabbitMqExtension
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services) 
        {
            services.AddRabbitMqMessageBroker(configuration =>
            {
                configuration.HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME") ?? "localhost";
                configuration.Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672");
                configuration.UserName = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "guest";
                configuration.Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
            });

            services.AddScoped<OrderCreatedHandler>();

            return services;
        }
    }
}
