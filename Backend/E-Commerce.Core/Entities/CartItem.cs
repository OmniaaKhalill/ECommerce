using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class CartItem
    {
    
        public int Id { get; set; }
        public int Quantity {  get; set; }
        public decimal price { get; set; }
        public color colors { get; set; }


    
    
    }
}
