using E_Commerce.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
    public class Order :BaseEntity
    {

      
        public DateTime orderDate{ get; set; }

        public int cartId {  get; set; }
        public Cart cart { get; set; }//one to many
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal TotalPrice { get; set; }

        public string ShippingAddress { get; set; }//user Address

        public string UserId {  get; set; }//forignKey
        public AppUser user {  get; set; }

        public ICollection<OrderItem> Items { get; set;}


    }
}
