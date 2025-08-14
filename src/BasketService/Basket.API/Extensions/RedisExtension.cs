using Basket.DAL.Options;

namespace Basket.API.Extensions
{
    public static class RedisExtension
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("BASKET_CONNECTION")
                ?? throw new InvalidOperationException($"Basket connection string not found in configuration.");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
                options.InstanceName = "BasketService:";
            });

            var expiryDays = configuration.GetValue<int>("EXPIRY_DAYS");

            services.Configure<RedisOptions>(options => 
            {
                options.ExpiryDays = expiryDays;
            });

            return services;
        }
    }
}
