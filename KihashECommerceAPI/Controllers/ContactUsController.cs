using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KihashECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }
        [HttpGet]
        
        public async Task<IActionResult>GetAll()
        {
            var obj = await _contactUsRepository.GetAllContactUs();
            return Ok(obj);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var obj=await _contactUsRepository.GetContactUsById(id);
            return Ok(obj);
        }
        [HttpPost]
      
        public async Task<IActionResult>AddContactUs(ContactUs contactUs)
        {
            var obj=await _contactUsRepository.AddContactUs(contactUs);
            return Ok(obj);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateContaUs(int id,ContactUs contactUs)
        {
            var obj = await _contactUsRepository.UpdateContactUs(id,contactUs);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteContactUs(int id)
        {
            var obj=await _contactUsRepository.DeleteContactUsById(id);
            return Ok(obj);
        }
    }
}
