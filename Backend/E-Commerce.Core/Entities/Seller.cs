using E_Commerce.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class Seller : BaseEntity
    {


        public string name { get; set; }
        public String IDImgUrl {  get; set; }
        public bool IsAccepted {  get; set; }
        public List<Product>? ProductList {  get; set; }//navigation

        [ForeignKey("Page")]

        public int? PageId { get; set; }
        public Page? Page {  get; set; }

    }
}
