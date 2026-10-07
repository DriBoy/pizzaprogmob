using BlazingPizzaApp.API.Data;
using BlazingPizzaApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizzaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveOrder(int id)
        {
            await _orderRepository.RemoveOrderAsync(id);
            return Ok();
        }
    }
}