using Microsoft.Extensions.DependencyInjection;
using Orders.Domain.Interfaces;
using Orders.Infrastructure.Repositories;

namespace Orders.Infrastructure.DI
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            return services;
        }
    }
}
