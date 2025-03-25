using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Model;

namespace KihashECommerceAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<int>AddProductAsync(Product product);
        Task<Product>UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
