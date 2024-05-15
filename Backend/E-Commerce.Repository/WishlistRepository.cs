using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly IDatabase db;

        public WishlistRepository(IConnectionMultiplexer redis, IDatabase db)
        {
            //this.context = redis;
            this.db = redis.GetDatabase();
        }
        public async Task<customerWishlist?> AddWishlistItem(string wishlistId, WishlistItem item)
        {
            var wishlist = await GetWishlistAsync(wishlistId);
            if (wishlist is null)
            {
                wishlist = new customerWishlist(wishlistId);
                await UpdateWishlistAsync(wishlist);
                await AddWishlistItem(wishlistId, item);
            }
            foreach (var wish in wishlist.Items)
            {
                if (wish.Id == item.Id)
                    await UpdateWishlistItemAsync(wishlistId, item);
            }
            wishlist.Items.Add(item);
            return await UpdateWishlistAsync(wishlist);
        }

        public async Task<bool> DeleteWishlistAsync(string wishlistId)
        {
            return await db.KeyDeleteAsync(wishlistId);
        }

        public async Task<customerWishlist?> DeleteWishlistItemAsync(string wishlistId, WishlistItem wishlistItem)
        {
            var wishlist = await GetWishlistAsync(wishlistId);
            if (wishlist is null)
                return null;
            foreach (var item in wishlist.Items)
            {
                if (item.Id == wishlistItem.Id)
                {
                    wishlist.Items.Remove(item);
                    return await UpdateWishlistAsync(wishlist);
                }
            }
            return null;
        }

        public async Task<customerWishlist?> GetWishlistAsync(string wishlistId)
        {
            var wishlist = await db.StringGetAsync(wishlistId);
            return wishlist.IsNullOrEmpty ? null : JsonSerializer.Deserialize<customerWishlist>(wishlist);
        }

        public async Task<customerWishlist?> UpdateWishlistAsync(customerWishlist wishlist)
        {
            var createdOrUpdated = await db.StringSetAsync(wishlist.Id, JsonSerializer.Serialize<customerWishlist>(wishlist), TimeSpan.FromDays(30));
            if (!createdOrUpdated)
                return null;
            return await GetWishlistAsync(wishlist.Id);
        }

        public async Task<customerWishlist?> UpdateWishlistItemAsync(string wishlistId, WishlistItem wishlistItem)
        {
            var wishlist = await GetWishlistAsync(wishlistId);
            if (wishlist is null)
                return null;
            var itemsToUpdate = wishlist.Items.FirstOrDefault(item => item.Id == wishlistItem.Id);
            return null;
        }
    }
}
