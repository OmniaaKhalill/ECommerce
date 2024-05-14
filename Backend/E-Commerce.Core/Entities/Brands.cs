using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class Brands : BaseEntity
    {
        public List<Product> Products { get; set; }
    }
}
