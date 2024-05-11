using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Product> ProductRepo { get; set; }
        public IGenericRepository<Category> CategoryRepo { get; set; }

        public UnitOfWork(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Category> categoryRepo
            )
        {
            ProductRepo = productRepo;
            CategoryRepo = categoryRepo;
        }
    }
}
