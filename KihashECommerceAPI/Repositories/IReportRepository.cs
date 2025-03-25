using KihashECommerceAPI.Model;

namespace KihashECommerceAPI.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<CustomerOrderDto>> GetAllCustomerWithOrderDetails();
        Task<IEnumerable<CustomerOrderDto>> GetAllCustomerWithOrderDetailsLeftjoin();
        Task <CustomerOrderDto?> GetCustomerWithOrderById(int id);
        Task<IEnumerable<CustomerOrderPaymentDto>> GetAllCustomerWithPaymentDetails();
    }
}
