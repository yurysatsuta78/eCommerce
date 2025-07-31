using Basket.DAL.Options;
using StackExchange.Redis;

namespace Basket.API.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            const string connectionName = "BasketConnection";

            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new InvalidOperationException($"Connection string '{connectionName}' was not found in the configuration.");

            services.AddSingleton<IConnectionMultiplexer>(options =>
                ConnectionMultiplexer.Connect(connectionString));

            services.Configure<RedisOptions>(configuration.GetSection(nameof(RedisOptions)));

            return services;
        }
    }
}
