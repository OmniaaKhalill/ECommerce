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
        public ProductSpecifications(ProductSpecParams specParams)
            : base(p =>
                (string.IsNullOrEmpty(specParams.brand) || p.brand == specParams.brand)
                &&
                (!specParams.CategoryId.HasValue || p.CategoryId == specParams.CategoryId.Value))
        {
            AddingIncludes();

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.price);
                        break;
                    default:
                        AddOrderBy(p => p.name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.name);
            }

            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }

        public ProductSpecifications(int id) :  base(p => p.id == id)
        {
            AddingIncludes();
        }

        private void AddingIncludes()
        {
            Includes.Add(p => p.Category);
            Includes.Add(p => p.seller);
            Includes.Add(p => p.Colors);
        }
    }
}
