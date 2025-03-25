
using KihashECommerceAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KihashECommerceAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
       

       
    }
}
