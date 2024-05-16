using E_Commerce.Core.Entities;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        Task<T?> GetAsync(int id);

      
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecifications<T> spec);
        Task<T?> GetSpecAsync(ISpecifications<T> spec);


        Task<int> GetCount(ISpecifications<T> spec);

        Task<bool> DeleteAsync(int id);


        Task<T?> UpdateAsync(int id, T entityToUpdate);

        Task<T?> AddAsync(T entity);

    }
}
