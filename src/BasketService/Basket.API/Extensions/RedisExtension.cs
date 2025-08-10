using Basket.DAL.Options;

namespace Basket.API.Extensions
{
    public static class RedisExtension
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = Environment.GetEnvironmentVariable("BASKET_CONNECTION")
                ?? throw new InvalidOperationException($"Basket connection string was not found in the environment.");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
                options.InstanceName = "BasketService:";
            });

            services.Configure<RedisOptions>(options => 
            {
                var expiryDaysEnv = Environment.GetEnvironmentVariable("EXPIRY_DAYS");

                if (!int.TryParse(expiryDaysEnv, out var expiryDays))
                    throw new InvalidOperationException("Invalid or missing EXPIRY_DAYS");

                options.ExpiryDays = expiryDays;
            });

            return services;
        }
    }
}
