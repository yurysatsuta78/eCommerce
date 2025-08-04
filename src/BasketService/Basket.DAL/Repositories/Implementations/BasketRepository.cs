using System.Text.Json;
using Basket.DAL.Models;
using Basket.DAL.Options;
using Basket.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.DAL.Repositories.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _cacheOptions;

        public BasketRepository(IDistributedCache cache, RedisOptions options)
        {
            _cache = cache;
            _cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(options.ExpiryDays)
            };
        }


        public async Task<CustomerBasketDb?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            var json = await _cache.GetStringAsync(customerId.ToString(), cancellationToken);

            if (string.IsNullOrEmpty(json)) 
            {
                return null;
            }

            return JsonSerializer.Deserialize<CustomerBasketDb>(json);
        }


        public Task UpdateAsync(CustomerBasketDb basket, CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(basket);

            return _cache.SetStringAsync(basket.CustomerId.ToString(), json, _cacheOptions, cancellationToken);
        }


        public Task DeleteAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return _cache.RemoveAsync(customerId.ToString(), cancellationToken);
        }
    }
}
