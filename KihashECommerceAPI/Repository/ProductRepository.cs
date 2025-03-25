using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KihashECommerceAPI.Services
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
           return await _context.Products.ToListAsync();
        }
        public async Task<Product?>GetProductByIdAsync(int id)
        {
           return  await _context.Products.FindAsync(id);
        }
        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
            
        }
        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var obj = await _context.Products.FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            obj.Name = product.Name;
            obj.Price = product.Price;
            obj.Quantity = product.Quantity;
            obj.Description = product.Description;
            obj.IsDeleted = product.IsDeleted;
            await _context.SaveChangesAsync();
            return obj;
        
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var obj = await _context.Products.FindAsync(id);
            if (obj == null)
            {
                return false;
            }
            _context.Products.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
