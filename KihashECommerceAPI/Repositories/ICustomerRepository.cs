using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Model;
using Azure.Identity;

namespace KihashECommerceAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer?> GetCustomerByUserName(string userName);
        Task<Customer?> GetCustomerByUserName2(string username);
         
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer>UpdateCustomerAsync(int id,Customer customer);    
       
        Task<bool> DeleteCustomerAsync(int id);
       
        bool LoginAPI(string userName, string password);
        

    }
}

