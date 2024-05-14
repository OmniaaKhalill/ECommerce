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
        public IGenericRepository<Seller> SellerRepo { get; set; }
        public IGenericRepository<Brands> BrandsRepo { get; set; }
        public IColorRepository ColotRepo { get; set; }

        public UnitOfWork(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Category> categoryRepo,
            IGenericRepository<Seller> sellerRepo,
            IGenericRepository<Brands> brandsRepo,
            IColorRepository colorRepo
            )
        {
            ProductRepo = productRepo;
            CategoryRepo = categoryRepo;
            SellerRepo = sellerRepo;
            BrandsRepo = brandsRepo;
            ColotRepo = colorRepo;
        }
    }
}
