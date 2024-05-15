﻿using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task <IEnumerable<Product>> GetAllPrpductByUserIdAsync(string UserId);

    }
}
