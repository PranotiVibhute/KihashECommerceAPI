using KihashECommerceAPI.Helper;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace KihashECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly TokenService _tokenRepository;

        public AuthController(ICustomerRepository customerRepository, TokenService tokenRepository)
        {
            _customerRepository = customerRepository;
            _tokenRepository = tokenRepository;
        }
        [HttpGet]

        public async Task<IActionResult> LoginAPI(string password, string username)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Ok("please enter username and password ");
            }
            var obj1 = await _customerRepository.GetCustomerByUserName(username);
            if (obj1 == null)
            {
                return Ok("Please enter correct username And password");
            }
            bool verifypassword = PasswordHelper.VerifyPassword(password, obj1.Password);
            if (verifypassword)
            {
                var token = _tokenRepository.GenerateToken(username);
                return Ok(new { token });
            }
            return Unauthorized("Enter correct Username and password");
            var obj = _customerRepository.LoginAPI(username, password);
            return Ok(obj);        
        }
        [HttpPost("login")]
        public async Task<IActionResult>LoginPostAPI([FromBody] Login login)
        {
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Please enter username and password.");
            }

            var customer = await _customerRepository.GetCustomerByUserName2(login.UserName);
            if (customer == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            bool isPasswordValid = PasswordHelper.VerifyPassword(login.Password , customer.Password);
            if (isPasswordValid)
            {
                var token = _tokenRepository.GenerateToken(login.UserName);
                return Ok(new { token });
            }
            
            return Unauthorized("Invalid username or password.");
        }
    }
}