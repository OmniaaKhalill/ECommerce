using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IColorRepository
    {
        Task<Coulor> GetByIdAsync(int id);
        Task<Coulor> GetByNameAsync(string name);
        Task AddAsync(Coulor color);
        Task UpdateAsync(Coulor color);
        Task DeleteAsync(int id);
    }
}
