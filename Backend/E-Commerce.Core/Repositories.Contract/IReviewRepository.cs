using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IReviewRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T review, int productId, string userId);
      


    }
}
