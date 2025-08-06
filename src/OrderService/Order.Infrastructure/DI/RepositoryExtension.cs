using Microsoft.Extensions.DependencyInjection;
using Order.Domain.Interfaces;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure.DI
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<ICustomerOrdersRepository, CustomerOrdersRepository>();

            return services;
        }
    }
}
