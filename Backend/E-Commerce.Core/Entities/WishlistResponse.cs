using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class WishlistResponse
    {
        public CustomerWishlist? Wishlist { get; set; }
        public string? Message { get; set; }
    }

}
