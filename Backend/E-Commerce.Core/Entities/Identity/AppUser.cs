using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
   
        public string? DisplayName {  get; set; }    
        public string? Address {  get; set; }
        public  ICollection<Review>? Reviews { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Payment>? Payment { get; set; }

        public WishList? WishList { get; set; }
    }
}
