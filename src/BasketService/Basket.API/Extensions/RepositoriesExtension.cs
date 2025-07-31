using Basket.DAL.Options;
using Basket.DAL.Repositories.Implementations;
using Basket.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Basket.API.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IBasketRepository>(sp =>
            {
                var redis = sp.GetRequiredService<IConnectionMultiplexer>();
                var options = sp.GetRequiredService<IOptions<RedisOptions>>().Value;

                return new BasketRepository(redis, options);
            });

            return services;
        }
    }
}
