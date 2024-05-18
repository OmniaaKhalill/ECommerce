using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class customerCart
    {
       
        public string Id {  get; set; }
        public List<CartItem> Items { get; set; }
        public int ? DeliveryMethodId { get; set; }   
        public decimal ShippingPrice { get; set; }
        public string ? PaymentIntentId { get; set; }
         public string ? ClientSecret { get; set; }

        public customerCart(string id)
        {
            Id = id;
            Items = new List<CartItem>();   
        }


    }
}
