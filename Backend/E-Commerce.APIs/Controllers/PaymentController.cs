using E_Commerce.Core.Entities;
using E_Commerce.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Forwarding;
using System.Threading.Tasks;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
         private const string _whSecret = "whsec_b3b89ff67c233477cdc1f5f5dceb4091e719a9814bc235ccdc75034f8118d8b8";


        public PaymentController(IPaymentService paymentService )
        {
            _paymentService = paymentService;
        }

        [ProducesResponseType(typeof(customerCart),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status400BadRequest)]
        [HttpPost("{cartId}")]
        public async Task <ActionResult<customerCart>> CreateOrUpdatePaymentIntent( string cartId)
        {
            var cart = await _paymentService.CreateOrUpdatePaymentIntent(cartId);
            if (cart == null) { return BadRequest(new ApiResponse(400, "an error with your cart ")); }
                return Ok(cart);
            
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> StripeHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], _whSecret);
                var paymentIntent = (PaymentIntent)stripeEvent.Data.Object;

                // Handle the event
                //switch (stripeEvent.Type)
                //{
                //    case Events.PaymentIntentSucceeded:
                //        await _paymentService.UpdatePaymentIntentToSuccededOrFailed(paymentIntent.Id, true);
                //        break;

                //     case Events.PaymentIntentPaymentFailed:
                //        await _paymentService.UpdatePaymentIntentToSuccededOrFailed(paymentIntent.Id, false);
                //        break;

                //}

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
  
   
}
