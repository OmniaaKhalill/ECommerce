using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications.ReviewSpecifications
{
    public class ReviewsWithProductSpec : BaseSpecifications<Review>
    {
        public ReviewsWithProductSpec() { Includes.Add(p => p.User); }

        public ReviewsWithProductSpec(int productId) : base(p => p.ProductId == productId)
        {
            AddingIncludes();
        }
      

        private void AddingIncludes()
        {
            Includes.Add(p => p.User);
           

        }
    }
}
