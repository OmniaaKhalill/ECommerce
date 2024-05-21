using E_Commerce.APIs.Controllers;
using E_Commerce.Core.Entities.Oreder_Agrigate;
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
    public class OrderRepo : GenericReposity<Order>, IOrderRepo
    {
        private readonly ProjectContext _dbcontext;

        public OrderRepo(ProjectContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IReadOnlyList<Order?>> GetOrdersByEmailAsync(string email)
        {
           return await  _dbcontext.orders.Include(o=>o.Items).Where(o=>o.BuyerEmail == email).ToListAsync();
        }

        public async Task<Order?> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {

           return  await _dbcontext.orders.Include(o => o.Items).SingleOrDefaultAsync(o=>o.id==orderId&& o.BuyerEmail==buyerEmail);
  
        }
        public async Task <Order> GetOrderByPaymentIdAsync(string paymentintentId)
        {
            return await _dbcontext.orders.Include(o => o.Items).SingleOrDefaultAsync(o => o.PaymentIntentId == paymentintentId);
        }

       
    }
}
