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

        public WishlistRepository(IConnectionMultiplexer redis)
        {
            this.db = redis.GetDatabase();
        }

        public async Task<CustomerWishlist?> AddWishlistItem(string wishlistId, WishlistItem item)
        {
            var wishlist = await GetWishlistAsync(wishlistId);
            if (wishlist == null)
            {
                wishlist = new CustomerWishlist(wishlistId);
                await UpdateWishlistAsync(wishlist);
                return await AddWishlistItem(wishlistId, item);  // Recursive call to add the item to the newly created wishlist
            }

            if (wishlist.Items.Any(wish => wish.Id == item.Id))
            {
                await UpdateWishlistItemAsync(wishlistId, item);  // Update the existing item if it already exists in the wishlist
            }
            else
            {
                wishlist.Items.Add(item);  // Add the new item to the wishlist
                await UpdateWishlistAsync(wishlist);
            }

            return wishlist;
        }


        public async Task<bool> DeleteWishlistAsync(string wishlistId)
        {
            return await db.KeyDeleteAsync(wishlistId);
        }

        //public async Task<WishlistResponse> DeleteWishlistItemAsync(string wishlistId, WishlistItem wishlistItem)
        //{
        //    var response = new WishlistResponse();
        //    var wishlist = await GetWishlistAsync(wishlistId);
        //    if (wishlist is null)
        //    {
        //        response.Message = "Wishlist not found";
        //        return response;
        //    }

        //    var item = wishlist.Items.FirstOrDefault(i => i.Id == wishlistItem.Id);
        //    if (item != null)
        //    {
        //        wishlist.Items.Remove(item);
        //        await UpdateWishlistAsync(wishlist);
        //        response.Wishlist = wishlist;
        //        response.Message = "Item removed successfully";
        //    }
        //    else
        //    {
        //        response.Message = "Item not found in wishlist";
        //    }

        //    return response;
        //}

        public async Task<CustomerWishlist?> GetWishlistAsync(string wishlistId)
        {
            var wishlistData = await db.StringGetAsync(wishlistId);
            return wishlistData.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerWishlist>(wishlistData);
        }

        public async Task<CustomerWishlist?> UpdateWishlistAsync(CustomerWishlist wishlist)
        {
            var createdOrUpdated = await db.StringSetAsync(wishlist.Id, JsonSerializer.Serialize(wishlist), TimeSpan.FromDays(30));
            if (!createdOrUpdated)
                return null;
            return wishlist;
        }

        public async Task<CustomerWishlist?> UpdateWishlistItemAsync(string wishlistId, WishlistItem wishlistItem)
        {
            var wishlist = await GetWishlistAsync(wishlistId);
            if (wishlist is null)
                return null;
            var item = wishlist.Items.FirstOrDefault(i => i.Id == wishlistItem.Id);
            if (item != null)
            {
                item.price = wishlistItem.price;
                await UpdateWishlistAsync(wishlist);
            }
            return wishlist;
        }

        public async Task<CustomerWishlist?> DeleteWishlistItemAsync(string wishlistId, WishlistItem wishlistItem)
        {
            var wishlist = await GetWishlistAsync(wishlistId);

            // Exit early if wishlist is null
            if (wishlist == null)
            {
                return null;
            }
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

        //Task<CustomerWishlist?> IWishlistRepository.DeleteWishlistItemAsync(string wishlistId, WishlistItem wishlistItem)
        //{
        //    //var message = "lol";
        //    //return message;
        //}
    }
}
