using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Model;

namespace KihashECommerceAPI.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllItemsAsync();
        Task<OrderItem?> GetItemsByIdAsync(int id);
        Task<OrderItem> AddOrderItemAsync(OrderItem item);
        Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem item);
        Task<bool> DeleteOrderItemAsync(int id);

    }
}
