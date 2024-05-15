using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class Coulor
    {

        public int Id{ get; set; }
        public string hex_value {  get; set; }
        public string colour_name { get; set; }

        public int ProductId {  get; set; }

        public Product Product { get; set; }
    
    }
}
