using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications.PageSpecifications
{
    public class PageSpec : BaseSpecifications<Page>
    {
        

        public PageSpec(int id) : base(p => p.id == id)
        { 
        }
        public PageSpec(int sellerId, bool isPageId) : base(p => p.SellerId == sellerId)
        {
        }


    }
}
