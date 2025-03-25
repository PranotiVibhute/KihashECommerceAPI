using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KihashCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderItem()
        {
            var obj = await _orderItemRepository.GetAllItemsAsync();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var obj = await _orderItemRepository.GetItemsByIdAsync(id);
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItem item)
        {
            var id = await _orderItemRepository.AddOrderItemAsync(item);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int id, OrderItem item)
        {
            var obj = await _orderItemRepository.UpdateOrderItemAsync(id, item);
            return Ok(obj);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int id)
        {
            var obj=await _orderItemRepository.DeleteOrderItemAsync(id);
            return Ok(obj);
        }

    }
}
