using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Oreder_Agrigate;
using E_Commerce.Core.Repositories.Contract;
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
        
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepositery _cartRepo;
        private readonly IPaymentService _paymentService;

        public OrderService(IUnitOfWork unitOfWork, ICartRepositery cartRepo,IPaymentService paymentService) 
        { 
           
            _unitOfWork = unitOfWork;
            _cartRepo = cartRepo;
            _paymentService = paymentService;
        }

        public async Task<Order?> CreateAsync(string buyerEmail, string CartId, int DeliveryMethodId, Address shippingAddress)
        {
       

            //1. get cart from repo 
            var cart = await _cartRepo.getCartAsync(CartId);

            //2. get slected items at cart from product repo
            var orderItems = new List<OrderItem>();
            if(cart?.Items?.Count>0)
            {
                foreach (var cartItem in cart.Items )
                {
                    var product = await _unitOfWork.ProductRepo.GetAsync(cartItem.Id);

                    var productItemOrder = new ProductItemOrder(cartItem.Id, product.name, product.image_link);
                    var orderItem = new OrderItem(productItemOrder, product.price, cartItem.Quantity);
                    orderItems.Add(orderItem);
                }

            }

            else
            {
                return null;
            }
            // 3.calculate subtotal
            var subTotal = orderItems.Sum(orderItem=> orderItem.Price*orderItem.Quantity);


            // 4.get delivery method from delivryMethod
            var delivryMethod= await _unitOfWork.DelivryMethosRepo.GetAsync(DeliveryMethodId);

            var existingOrder = await _unitOfWork.OrdersRepo.GetOrderByPaymentIdAsync(cart.PaymentIntentId);
            if (existingOrder != null)
            {
                await _unitOfWork.OrdersRepo.DeleteAsync(existingOrder.id);
                await _paymentService.CreateOrUpdatePaymentIntent(CartId);

            }
            // 5.create order
            var order = new Order(buyerEmail, shippingAddress,delivryMethod, orderItems, subTotal,cart.PaymentIntentId);

            await _unitOfWork.OrdersRepo.AddAsync(order);


            var result = await _unitOfWork.OrdersRepo.Complete();

            if (result <= 0) return null;

            return order;

        }

        public async Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {


          return await  _unitOfWork.OrdersRepo.GetOrderByIdForUserAsync(orderId, buyerEmail);   

        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
           var orders=  await _unitOfWork.OrdersRepo.GetOrdersByEmailAsync(buyerEmail);

           return orders;
        }
         public async Task<Order> GetOrderByPaymentId(string PaymentintentId)
        {
            var order = await _unitOfWork.OrdersRepo.GetOrderByPaymentIdAsync(PaymentintentId);
            return order;

        }
    }
}
