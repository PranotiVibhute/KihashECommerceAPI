using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using KihashECommerceAPI.Repositories;

namespace KihashECommerceAPI.Services
{
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Order>>GetAllOrderAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
            //if(obj==null)
            //{
            //    return NotFound();
               
            //}
            //return obj;
        }
        public async Task<Order>AddOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
             await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            var obj = await _dbContext.Orders.FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            obj.CustomerId= order.CustomerId;
            obj.TotalAmount= order.TotalAmount;
            obj.Status= order.Status;
            obj.OrderDate= order.OrderDate;
            await _dbContext.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var obj = await _dbContext.Orders.FindAsync(id);
            if (obj == null)
                return false;
            _dbContext.Orders.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
