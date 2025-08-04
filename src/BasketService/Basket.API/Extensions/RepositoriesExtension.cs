using Basket.DAL.Options;
using Basket.DAL.Repositories.Implementations;
using Basket.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Basket.API.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IBasketRepository>(sp =>
            {
                var cache = sp.GetRequiredService<IDistributedCache>();
                var options = sp.GetRequiredService<IOptions<RedisOptions>>().Value;

                return new BasketRepository(cache, options);
            });

            return services;
        }
    }
}
