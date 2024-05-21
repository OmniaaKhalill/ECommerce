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

        public string name { get; set; }
        public string Description { get; set; }

        public int SellerId { get; set; }//forignKey (seller)
        public Seller? seller { get; set; }//navigation prop




    }
}
