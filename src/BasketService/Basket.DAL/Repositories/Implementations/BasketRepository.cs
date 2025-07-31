using System.Text.Json;
using Basket.DAL.Models;
using Basket.DAL.Options;
using Basket.DAL.Repositories.Interfaces;
using StackExchange.Redis;

namespace Basket.DAL.Repositories.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        private readonly TimeSpan _expiryDays;

        public BasketRepository(IConnectionMultiplexer database, RedisOptions options)
        {
            _database = database.GetDatabase();
            _expiryDays = TimeSpan.FromDays(options.ExpiryDays);
        }

        public async Task<CustomerBasketDb?> GetByCustomerIdAsync(Guid customerId)
        {
            var basketData = await _database.StringGetAsync(customerId.ToString());

            var basket = JsonSerializer.Deserialize<CustomerBasketDb>(basketData);

            return basket;
        }

        public async Task<bool> UpdateAsync(CustomerBasketDb basket)
        {
            return await _database.StringSetAsync(
                basket.CustomerId.ToString(), 
                JsonSerializer.Serialize(basket), 
                _expiryDays);
        }

        public async Task<bool> DeleteAsync(Guid customerId)
        {
            return await _database.KeyDeleteAsync(customerId.ToString());
        }
    }
}
