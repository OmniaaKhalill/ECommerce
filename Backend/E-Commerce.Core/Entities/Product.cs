using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public class Product:BaseEntity
    {
    
        public string brand {  get; set; }
        public decimal price {  get; set; }
        public string description {  get; set; }

        public string image_link {  get; set; }

        public int? CategoryId {  get; set; }//forignKey(Category)

        public Category Category { get; set; }//navigation prop
        public int? colourId {  get; set; }//foriggnkey(color table)
        public List<Color>? Colors { get; set; }//MultiValuedAtrribute,//navigation prop

        public List<Tag>? tag_list { get; set; }//navigation prop


    }
}
