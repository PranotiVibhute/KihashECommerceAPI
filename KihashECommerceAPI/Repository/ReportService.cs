using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KihashECommerceAPI.Repository
{
    public class ReportService:IReportRepository
    {
        private readonly AppDbContext _dbContext;
        public ReportService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CustomerOrderDto>>GetAllCustomerWithOrderDetails()
        {
            var result = from c in _dbContext.Customers
                         join o in _dbContext.Orders
                         on c.CustomerId equals o.CustomerId
                         select new CustomerOrderDto
                         {
                             CustomerName = c.Name,
                             OrderId = o.OrderId,
                             OrderDate = o.OrderDate
                         };            
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<CustomerOrderPaymentDto>> GetAllCustomerWithPaymentDetails()
        {
            var result = from c in _dbContext.Customers
                         join o in _dbContext.Orders
                         on c.CustomerId equals o.CustomerId
                         join p in _dbContext.Payments
                         on o.OrderId equals p.OrderId
                         select new CustomerOrderPaymentDto
                         {
                             CustomerName = c.Name,
                             OrderId = o.OrderId,
                             OrderDate = o.OrderDate,
                             PaymentId = p.PaymentId,
                             Amount = p.Amount,
                             Status = p.Status
                         };
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<CustomerOrderDto>> GetAllCustomerWithOrderDetailsLeftjoin()
        {
            var result = from c in _dbContext.Customers
                         join o in _dbContext.Orders
                         on c.CustomerId equals o.CustomerId
                         into customerOrders
                         from co in customerOrders.DefaultIfEmpty()
                         select new CustomerOrderDto
                         {
                             CustomerName = c.Name,
                             OrderId = co.OrderId,
                             OrderDate = co.OrderDate
                         };
            return await result.ToListAsync();                         
        }

        public async Task<IEnumerable<CustomerOrderDto?>> GetCustomerWithOrderById(int id)
        {
            var result = from c in _dbContext.Customers
                         join o in _dbContext.Orders
                         on c.CustomerId equals o.CustomerId
                         where c.CustomerId == id
                         select new CustomerOrderDto
                         {
                             CustomerId = c.CustomerId,
                             CustomerName = c.Name,
                             OrderId = o.OrderId,
                             OrderDate = o.OrderDate
                         };
            return await result.ToListAsync();
        }
    }
}
