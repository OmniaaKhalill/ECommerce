using E_Commerce.Core.Entities;
using E_Commerce.Core.Specifications.ProductSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product>
    {
        //public ProductSpecifications(int id) : base(p => p.id == id)
        //{
        //    AddingIncludes();
        //}       
        public ProductSpecifications(ProductSpecParams specParams) : base()
        {
            AddingIncludes();
            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }

        public ProductSpecifications(int id) :  base(p => p.id == id)
        {
            AddingIncludes();
        }

        public void AddingIncludes()
        {
            Includes.Add(p => p.Category);
            Includes.Add(p => p.seller);
        }
    }
}
