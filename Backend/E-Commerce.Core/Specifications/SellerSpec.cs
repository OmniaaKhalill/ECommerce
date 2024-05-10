using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications
{
    public class SellerSpec : BaseSpecifications<Seller>
    {
        public SellerSpec() : base()
        {
            AddingIncludes();
        }
        public SellerSpec(int id) : base(s => s.id == id)
        {
            AddingIncludes();
        }

        public void AddingIncludes()
        {
            Includes.Add(p => p.Page);
        }
    }
}
