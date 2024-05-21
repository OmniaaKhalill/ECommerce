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
        Task<CustomerWishlist?> GetWishlistAsync(string wishlistId);
        Task<CustomerWishlist?> UpdateWishlistAsync(CustomerWishlist wishlist);
        Task<bool> DeleteWishlistAsync(string wishlistId);
        Task<CustomerWishlist?> AddWishlistItem(string wishlistId, WishlistItem item);
        Task<CustomerWishlist?> UpdateWishlistItemAsync(string wishlistId, WishlistItem wishlistItem);
        Task<CustomerWishlist?> DeleteWishlistItemAsync(string wishlistId, WishlistItem wishlistItem);
    }
}
