using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Core.Entities.Identity;

namespace E_Commerce.Core.Entities
{
    public class Review :BaseEntity
    {
       
        public string Content { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; } //forignKey
        public int ProductId { get; set; }//forignKey
        public AppUser User { get; set; }
        public Product Product { get; set; }
        public DateTime DatePosted { get; set; }


    }
}
