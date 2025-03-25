using KihashECommerceAPI.Model;

namespace KihashECommerceAPI.Repositories
{
    public interface IContactUsRepository
    {
        Task<IEnumerable<ContactUs>> GetAllContactUs();
        Task<ContactUs?> GetContactUsById(int id);
        Task<ContactUs?> AddContactUs(ContactUs contactUs);
        Task <ContactUs>UpdateContactUs(int id,ContactUs contactUs);
        Task<bool> DeleteContactUsById(int id);
    }
}
