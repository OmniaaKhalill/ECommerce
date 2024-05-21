using E_Commerce.Core.Entities.Oreder_Agrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IOrderRepo :IGenericRepository<Order>
    {

        Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail);
        Task <Order> GetOrderByPaymentIdAsync(string paymentintentId);

        Task<IReadOnlyList<Order>> GetOrdersByEmailAsync(string email );
    }
}
