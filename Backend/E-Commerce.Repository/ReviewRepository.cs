using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class ReviewRepository<T> : IReviewRepository<T> where T : BaseEntity
    {

        private readonly ProjectContext _dbContext;

        public ReviewRepository(ProjectContext dbContext)
        {
         _dbContext = dbContext;
        }
       
        public async Task<T>  AddAsync(T entity, int productId, string userId)
        {

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

      
    }
}
