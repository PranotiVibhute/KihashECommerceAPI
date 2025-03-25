using KihashECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KihashECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("GetCustomerOrderPaymentDetails")]
        public async Task<IActionResult> GetAllCustomerWithPaymentDetails()
        {
            var result = await _reportRepository.GetAllCustomerWithPaymentDetails();
            return Ok(result);
        }

        [HttpGet("GetAllCustomerWithOrderDetailsLeftjoin")]
        public async Task<IActionResult> GetAllCustomerWithOrderDetailsLeftjoin()
        {
            var result = await _reportRepository.GetAllCustomerWithOrderDetailsLeftjoin();
            return Ok(result);

        }
    }
}
