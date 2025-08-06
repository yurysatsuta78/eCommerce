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
            const string connectionName = "OrdersConnection";

            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new InvalidOperationException($"Connection string '{connectionName}' was not found in the configuration.");

            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
