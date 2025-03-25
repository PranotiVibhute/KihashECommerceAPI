using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace KihashECommerceAPI.Repository
{
    public class LINQ_Query
    {
        private readonly AppDbContext _dbContext;
        public LINQ_Query(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<Customer?> GetAll()
        //{
        //    var res = await _dbContext.FromExpression
           
        //}
    }
}
