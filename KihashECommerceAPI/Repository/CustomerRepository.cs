using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using KihashECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace KihashECommerceAPI.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
        public async Task<Customer?> GetCustomerByUserName(string username)
        {
            var obj = await _dbContext.Customers.FirstOrDefaultAsync(u => u.UserName == username);
            return obj;
        }
        public async Task<Customer?> GetCustomerByUserName2(string username)
        {
            var obj = await _dbContext.Customers.
                Where(u => u.UserName == username)
                .Select(s => new Customer{Password = s.Password , Email = s.Email }).FirstOrDefaultAsync();
            return obj;
        }
       
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            var obj = await _dbContext.Customers.FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            obj.Name = customer.Name;
            obj.Email = customer.Email;
            obj.Address = customer.Address;
            obj.IsDeleted = customer.IsDeleted;
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var obj = await _dbContext.Customers.FindAsync(id);
            if (obj == null)
                return false;
            _dbContext.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;

        }     

        public bool LoginAPI(string username, string password)
        {
            var obj = _dbContext.Customers.Where(u => u.UserName == username && u.Password == password);
            if (obj != null)
            {
                return true;
            }
            return false;
        }      

       
    }
}
