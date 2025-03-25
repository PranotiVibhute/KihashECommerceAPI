using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KihashCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var obj = await _productRepository.GetAllProductAsync();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var obj = await _productRepository.GetProductByIdAsync(id);
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var id = await _productRepository.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id }, product);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateProductAsync(int id,Product product)
        {
            var obj=await _productRepository.UpdateProductAsync(id,product);   
            return Ok(obj);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProductAsync(int id)
        {
            var obj=await _productRepository.DeleteProductAsync(id);
            return Ok(obj);

        }
    }
}