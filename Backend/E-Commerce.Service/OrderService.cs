using E_Commerce.Core.Entities.Oreder_Agrigate;
using E_Commerce.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateAsync(string buyerEmail, string basketId, int DeliveryMethodId, Address shippingAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
