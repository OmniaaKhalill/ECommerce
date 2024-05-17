using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities.Oreder_Agrigate;
using E_Commerce.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            var shippingAddress = _mapper.Map<AddressDto, Address>(orderDto.shippingAddress);
            var createdOrder = await _orderService.CreateAsync(orderDto.buyerEmail, orderDto.CartId, orderDto.DeliveryMethodId, shippingAddress);


            if (createdOrder == null)
            {
                return BadRequest(400);
            }


            var order = _mapper.Map<OrderDto>(createdOrder);

            return Ok(order);

        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUser(string email)
        {
            var orders = await _orderService.GetOrdersForUserAsync(email);

            if (orders == null )
            {
                return NotFound(404); // Return 404 if no orders are found
            }

            return Ok(orders); // Return 200 with the list of orders
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderForUser(int orderId, string email)
        {
            var order = await _orderService.GetOrderByIdForUserAsync(orderId, email);  

            if (order == null)
            {
                return NotFound(404); // Return 404 if no orders are found
            }

            return Ok(order); // Return 200 with the list of orders
        }


    }
}
