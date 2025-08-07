using Basket.DAL.Options;

namespace Basket.API.Extensions
{
    public static class RedisExtension
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration) 
        {
            const string connectionName = "BasketConnection";

            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new InvalidOperationException($"Connection string '{connectionName}' was not found in the configuration.");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
                options.InstanceName = "BasketService:";
            });

            services.Configure<RedisOptions>(configuration.GetSection(nameof(RedisOptions)));

            return services;
        }
    }
}
