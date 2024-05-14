using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications.ProductSpecs
{
    public class ProductsWithFilterationForCountSpecifications : BaseSpecifications<Product>
    {
        public ProductsWithFilterationForCountSpecifications(ProductWithPaginationSpecParams specParams): base()
        {
            
        }
        public ProductsWithFilterationForCountSpecifications(ProductSpecParams specParams)
            : base(p =>
                (!specParams.Brandsid.HasValue || p.Brandsid == specParams.Brandsid.Value)
                &&
                (!specParams.CategoryId.HasValue || p.CategoryId == specParams.CategoryId.Value))
        {
        }
    }
}
