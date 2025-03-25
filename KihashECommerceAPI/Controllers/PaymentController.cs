using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KihashCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayment()
        {
            var obj = await _paymentRepository.GetAllPaymentAsync();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var obj = await _paymentRepository.GetPaymentByIdAsync(id);
            return Ok(obj);
        }
        [HttpPost]
        public async Task<IActionResult>CreatePayment([FromBody] Payment payment)
        {
            var id = await _paymentRepository.AddPaymentAsync(payment);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdatePaymentAsync(int id,Payment payment)
        {
            var obj=await _paymentRepository.UpdatePaymentAsync(id, payment);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeletePaymentAsync(int id)
        {
            var obj=await _paymentRepository.DeletePaymentAsync(id);
            return Ok(obj);
        }       

    }
}
