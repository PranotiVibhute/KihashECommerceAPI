using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repository;

namespace KihashECommerceAPI.Repositories
{
    public interface ILINQQuery
    {
        Task<Customer> GetAll();
    }
}
