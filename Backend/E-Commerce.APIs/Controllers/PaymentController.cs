using E_Commerce.Core.Entities;
using E_Commerce.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;

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
    }
}
