using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities.Oreder_Agrigate
{
    public class Order:BaseEntity
    {
        public Order()
        {
            
        }
        public Order(string buyerEmail, Address shippingAddress,  ICollection<OrderItem> items, decimal subTotal,string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
        
            ShippingAddress = shippingAddress;
            Items = items;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShippingAddress { get; set; }
        public ICollection<OrderItem> Items { get; set; }  = new HashSet<OrderItem>();
        public decimal SubTotal { get; set; }
        public decimal GetTotal() => SubTotal;
        public string PaymentIntentId { get; set; } 
    }
}
