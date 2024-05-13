using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Services.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = E_Commerce.Core.Entities.Product;

namespace E_Commerce.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepositery _cartRepositery;
        private readonly IConfiguration _configuration;

        public PaymentService(IUnitOfWork unitOfWork ,ICartRepositery icartRepositery ,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _cartRepositery = icartRepositery;
            _configuration = configuration;
        }
        public async Task<customerCart> CreateOrUpdatePaymentIntent(string cartid)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
            var cart= await _cartRepositery.getCartAsync(cartid);
            if (cart is null) return null;
            if (cart.Items.Count > 0)
            {
                foreach (var item in cart.Items)
                {
                    var product = await _unitOfWork.ProductRepo.GetAsync(item.Id);
                    if(item.price != product.price)
                    {
                        item.price = product.price;
                    }


                }
            }
            PaymentIntentService paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if(string.IsNullOrEmpty(cart.PaymentIntentId)) //create new 
            {
                var CreateOptions = new PaymentIntentCreateOptions()
                {
                    Amount = (long)cart.Items.Sum(item => item.price * item.Quantity * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>() { "card" }


                };
               paymentIntent= await paymentIntentService.CreateAsync(CreateOptions);
                cart.PaymentIntentId = paymentIntent.Id;
                cart.ClientSecret = paymentIntent.ClientSecret;

            }
            else
            {
                var UpdateOptions = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)cart.Items.Sum(item => item.price * item.Quantity * 100)

                };
                await paymentIntentService.UpdateAsync(cart.PaymentIntentId, UpdateOptions);


            }
            await _cartRepositery.UpdateCartAsync(cart);
            return cart;

        }
        public async Task<Order> UpdatePaymentIntentToSuccededOrFailed(string paymentid,bool issucess)
        {
            //var spec =new orderwithpaymentintentidspecifications()
            return new Order { };
            //neeeed the ordeeeeer 

        }
    }
}
