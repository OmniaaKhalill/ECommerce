using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Oreder_Agrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> ProductRepo { get; set; }
        IGenericRepository<Category> CategoryRepo { get; set; }
        IGenericRepository<Seller> SellerRepo { get; set; }
        IColorRepository ColotRepo { get; set; }
        IGenericRepository<DeliveryMethod> DelivryMethosRepo { get; set; }
        IOrderRepo OrdersRepo { get; set; }
    }
}
