using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IWishlistRepository
    {
        Task<customerWishlist?> GetWishlistAsync(string wishlistId);
        Task<customerWishlist?> UpdateWishlistAsync(customerWishlist wishlist);
        Task<bool> DeleteWishlistAsync(string wishlistId);
        Task<customerWishlist?> AddWishlistItem(string wishlistId, WishlistItem item);
        Task<customerWishlist?> UpdateWishlistItemAsync(string wishlistId, WishlistItem wishlistItem);
        Task<customerWishlist?> DeleteWishlistItemAsync(string wishlistId, WishlistItem wishlistItem);
    }
}
