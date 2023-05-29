using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Controllers
{
    /// <summary>
    /// Controller for handling orders.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Gets an order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>The order with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {
            try
            {
                return Ok(await _orderRepository.GetOrderByIdAsync(id));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="orderCreatingDto">The data for the new order.</param>
        /// <returns>The newly created order.</returns>
        [HttpPost, Authorize]
        public async Task<ActionResult<Order>> CreateOrderAsync(OrderCreatingDto orderCreatingDto)
        {
            try
            {
                int userId = int.Parse(User.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                return Ok(await _orderRepository.CreateOrderAsync(orderCreatingDto, userId));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}