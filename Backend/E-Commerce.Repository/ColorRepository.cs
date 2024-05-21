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
    public class ColorRepository : IColorRepository
    {
        private readonly ProjectContext dbContext;

        public ColorRepository(ProjectContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Coulor> GetByIdAsync(int id)
        {
            return await dbContext.colors.FindAsync(id);
        }

        public async Task<Coulor> GetByNameAsync(string name)
        {
            return await dbContext.colors.FirstOrDefaultAsync(c => c.colour_name == name);
        }

        public async Task AddAsync(Coulor color)
        {
            dbContext.colors.Add(color);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coulor color)
        {
            dbContext.Entry(color).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var color = await dbContext.colors.FindAsync(id);
            if (color != null)
            {
                dbContext.colors.Remove(color);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

