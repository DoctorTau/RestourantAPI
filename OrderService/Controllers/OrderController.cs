using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

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