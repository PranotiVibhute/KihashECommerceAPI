using KihashECommerceAPI.Model;

namespace KihashECommerceAPI.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllPaymentAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<Payment>AddPaymentAsync(Payment payment);
        Task<Payment> UpdatePaymentAsync(int id, Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}
