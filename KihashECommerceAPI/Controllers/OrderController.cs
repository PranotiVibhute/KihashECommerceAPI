using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KihashCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllOrderAsync()
        {   //Without creating a variable they give a error
            var obj= await _orderRepository.GetAllOrderAsync();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetOrderById(int id)
        {
            var obj= await _orderRepository.GetOrderByIdAsync(id);
            if(obj==null)
            {
                return NotFound("Id is NotFound");
            }
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult>CraeteOrder ([FromBody] Order order)
        {
            var id=await _orderRepository.AddOrderAsync(order);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateOrder(int id,Order order)
        {
            var obj=await _orderRepository.UpdateOrderAsync(id,order);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteOrderAsync(int id)
        {
            var obj=await _orderRepository.DeleteOrderAsync(id);
            return Ok(obj);

        }

    }
}
