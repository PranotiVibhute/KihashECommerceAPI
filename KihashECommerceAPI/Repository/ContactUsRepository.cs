using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace KihashECommerceAPI.Repository
{
    public class ContactUsRepository:IContactUsRepository
    {
        private readonly AppDbContext _dbContext;
        public ContactUsRepository(AppDbContext dbContext)
        {
        _dbContext = dbContext; 
        }        
        public async Task<IEnumerable<ContactUs>> GetAllContactUs()
        { 
            return await _dbContext.ContactUs.ToListAsync();
        }
        public async Task<ContactUs?> GetContactUsById(int id)
        {
            return await _dbContext.ContactUs.FindAsync(id);            
        }
        public async Task<ContactUs?> AddContactUs(ContactUs contactUs)
        {
            _dbContext.ContactUs.Add(contactUs);
            await _dbContext.SaveChangesAsync();
            return contactUs;
        }
        public async Task<bool> DeleteContactUsById(int id)
        {
            var obj = await _dbContext.ContactUs.FindAsync(id);
            if(obj == null)
            {
                return false;
            }
            _dbContext.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ContactUs> UpdateContactUs(int id, ContactUs contactUs)
        {
           var obj= await _dbContext.ContactUs.FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            obj.ContactName = contactUs.ContactName;
            obj.Mobile=contactUs.Mobile;
            obj.Gender=contactUs.Gender;
            obj.Email=contactUs.Email;
            obj.Amount=contactUs.Amount;
            obj.City=contactUs.City;
            obj.Address=contactUs.Address;
            await _dbContext.SaveChangesAsync();
            return obj;
        }

    }
}
