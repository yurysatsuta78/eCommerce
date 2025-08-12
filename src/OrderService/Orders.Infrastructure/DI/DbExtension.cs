using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Infrastructure.Data;

namespace Orders.Infrastructure.DI
{
    public static class DbExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = Environment.GetEnvironmentVariable("ORDERS_CONNECTION")
                ?? throw new InvalidOperationException($"Orders connection string not found in the environment.");

            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
