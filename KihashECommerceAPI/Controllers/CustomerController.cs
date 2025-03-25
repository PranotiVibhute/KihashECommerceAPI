using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using KihashECommerceAPI.Helper;

namespace KihashECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IReportRepository _reportRepository;
        public CustomerController(ICustomerRepository customerRepository,IReportRepository reportRepository)
        {
            _customerRepository = customerRepository;
            _reportRepository = reportRepository;
        }
        [HttpGet("Query")]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetMyModels()
        //{
        //    var obj = await _customerRepository.GetAll();
        //    return Ok(obj);
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var obj = await _customerRepository.GetAllCustomersAsync();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await _customerRepository.GetCustomerByIdAsync(id));
        }
        [HttpGet("username")]
        public async Task<IActionResult> GetCustomerByUsername(string username)
        {
            return Ok(await _customerRepository.GetCustomerByUserName(username));
        }
        
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if(customer.UserName== null || customer.Password == null)
            {
                return Ok("Invalid  data");
            }
            var hashedPassword = PasswordHelper.EncryptPassword(customer.Password);
            customer.Password = hashedPassword;
            var obj = await _customerRepository.AddCustomerAsync(customer);
           return Ok(obj);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateCustomer(int id,Customer customer)
        {
            var obj= await _customerRepository.UpdateCustomerAsync(id,customer);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var obj = await _customerRepository.DeleteCustomerAsync(id);
            return Ok(obj);
        }

        //--report interface = getAllCustomerWithOrderDetails
        //     GetCustomerAllOrderByCustId(int id)
        //     ,service,
        //[HttpGet("where")]
        //public async Task<IActionResult>GetWhere()
        //{
        //    var obj = await _customerRepository.GetAllS();
        //    return Ok(obj); 
        //}

        [HttpGet("GetCustomerOrder")]
        public async Task<IActionResult> GetAllCustomerOrder()
        {
            var obj = await  _reportRepository.GetAllCustomerWithOrderDetails();
            return Ok(obj);
        }

       
    }
}
