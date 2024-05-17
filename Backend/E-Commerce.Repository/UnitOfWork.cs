using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Oreder_Agrigate;
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
        public IColorRepository ColotRepo { get; set; }

       
        public IGenericRepository<DeliveryMethod> IDelivryMethosRepo { get; set; }
        public IOrderRepo OrdersRepo { get; set; }
        public IGenericRepository<DeliveryMethod> DelivryMethosRepo { get; set; }

        public UnitOfWork(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Category> categoryRepo,
            IGenericRepository<Seller> sellerRepo,
            IColorRepository colorRepo,
            ICartRepositery cartRepo, 
            IGenericRepository<DeliveryMethod> delivryMethosRepo,
            IOrderRepo  ordersRepo
            )
        



            
        {
            ProductRepo = productRepo;
            CategoryRepo = categoryRepo;
            SellerRepo = sellerRepo;
            ColotRepo = colorRepo;

           DelivryMethosRepo = delivryMethosRepo;
           OrdersRepo = ordersRepo;
        }
    }
}
