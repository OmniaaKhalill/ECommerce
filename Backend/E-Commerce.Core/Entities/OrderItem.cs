using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }//forignkey
        public  Product Product { get; set; }

        public int OrderId {  get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }

    }
}
