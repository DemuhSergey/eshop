using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastracture.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            await _redisCache.RemoveAsync(userName, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await _redisCache.GetStringAsync(userName, cancellationToken);
            if (string.IsNullOrEmpty(basket))
            {
                return null!;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket)!;
        }

        public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket), cancellationToken);
            return await GetBasketAsync(basket.UserName, cancellationToken);
        }
    }
}
