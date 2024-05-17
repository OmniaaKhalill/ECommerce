using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class CustomerWishlist
    {
        public string Id { get; set; }
        public List<WishlistItem> Items { get; set; }

        public CustomerWishlist(string id)
        {
            Id = id;
            Items = new List<WishlistItem>();
        }
    }
}
