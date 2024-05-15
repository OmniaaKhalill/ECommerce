﻿using E_Commerce.APIs.Controllers;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class SellerRepository : GenericReposity<Seller>, ISellerRepository
    {
        private readonly ProjectContext _dbcontext;

        public SellerRepository(ProjectContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Product>> GetAllPrpductByUserIdAsync(string UserId)
        {
         
            var seller = await _dbcontext.sellers.FirstOrDefaultAsync(x => x.UserId == UserId);

            if (seller == null)
            {
               
                return Enumerable.Empty<Product>();
            }

            //get products by seller
            return await _dbcontext.products.Where(p => p.SellerId == seller.id).ToListAsync();
        }

    }
}
