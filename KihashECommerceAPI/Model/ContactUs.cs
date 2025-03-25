using System.ComponentModel.DataAnnotations;

namespace KihashECommerceAPI.Model
{
    public class ContactUs
    {
        [Key]
        public int ContactId {  get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
