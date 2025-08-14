using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Infrastructure.DI;

namespace Orders.Infrastructure
{
    public static class ConfigureInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDatabase(configuration);
            services.AddAutoMapper();
            services.AddGrpcClients(configuration);
            services.AddRabbitMq();
            services.AddRepositories();

            return services;
        }
    }
}
