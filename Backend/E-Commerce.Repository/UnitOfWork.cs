using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
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
        public IGenericRepositoryUser<AppUser> UserRepo { get; set; }

        public IReviewRepository<Review> ReviewRepo { get; set; }
        public IColorRepository ColotRepo { get; set; }

        public UnitOfWork(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Category> categoryRepo,
            IGenericRepository<Seller> sellerRepo,
            IGenericRepositoryUser<AppUser> userRepo,
            IReviewRepository<Review> reviewRepo,

            IColorRepository colorRepo
            )
        {
            ProductRepo = productRepo;
            CategoryRepo = categoryRepo;
            SellerRepo = sellerRepo;
            ColotRepo = colorRepo;
            UserRepo = userRepo;
            ReviewRepo = reviewRepo;
        }
    }
}
