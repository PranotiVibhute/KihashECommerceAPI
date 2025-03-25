using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KihashECommerceAPI.Services
{
    public class OrderItemRepository:IOrderItemRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<OrderItem>> GetAllItemsAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }
        public async Task<OrderItem?> GetItemsByIdAsync(int id)
        {
            return await _dbContext.OrderItems.FindAsync(id);
        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItem item)
        {
            _dbContext.OrderItems.Add(item);
             await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem item)
        {
            var obj = await _dbContext.OrderItems.FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            obj.OrderId = item.OrderId;
            obj.ProductId = item.ProductId;
            obj.Quantity = item.Quantity;
            obj.PriceAtOrder = item.PriceAtOrder;
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            var obj = await _dbContext.OrderItems.FindAsync(id);
            if (obj == null)
            {
                return false;
            }
            _dbContext.OrderItems.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
