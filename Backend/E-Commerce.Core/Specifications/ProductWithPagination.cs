using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications
{
    public class ProductWithPagination : BaseSpecifications<Product>
    {
        public ProductWithPagination(ProductWithPaginationSpecParams specParams): base()
        {
            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }
    }
}
