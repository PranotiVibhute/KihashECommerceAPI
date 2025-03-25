using KihashECommerceAPI.Repositories;
using KihashECommerceAPI.Data;
using KihashECommerceAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace KihashECommerceAPI.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly AppDbContext _dbContext;
        public PaymentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Payment>> GetAllPaymentAsync()
        {
            return await _dbContext.Payments.ToListAsync();
        }
        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _dbContext.Payments.FindAsync(id);
        }
        public async Task<Payment>AddPaymentAsync(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }
        public async Task<Payment> UpdatePaymentAsync(int id, Payment payment)
        {
            var obj = await _dbContext.Payments.FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            obj.OrderId = payment.OrderId;
            obj.Amount = payment.Amount;
            obj.Status = payment.Status;
            obj.PaymentType = payment.PaymentType;
            obj.PaymentDate = payment.PaymentDate;
            await _dbContext.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeletePaymentAsync(int id)
        {
            var obj = await _dbContext.Payments.FindAsync(id);
            if (obj == null) return false;
            _dbContext.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
