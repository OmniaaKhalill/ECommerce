using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public  class Page:BaseEntity
    {
  
        public string Description { get; set; }

        //[ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

    
    
    
    }
}
