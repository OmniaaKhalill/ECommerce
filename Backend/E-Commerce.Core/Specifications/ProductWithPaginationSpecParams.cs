using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications
{
    public class ProductWithPaginationSpecParams
    {
        private const int MaxPageSize = 10; // Max size for pages
        private int pageSize = 5; // Default for Pages
        private int pageIndex = 0; // Default PageIndex

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value >= 0 ? value : 0; }
        }
    }
}
