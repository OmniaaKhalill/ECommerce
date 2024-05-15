using E_Commerce.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class Cart
    {
    
        public int Id { get; set; }

        public string userId {  get; set; }
        public AppUser user { get; set; }

        public List<Product> products {  get; set; } //many-to-many

        public List<Order> order { get; set; }
    
    }
}
