namespace KihashECommerceAPI.Model
{
    public class Customer
    {
        public int CustomerId {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public bool IsDeleted { get; set; }

        public string? UserName {  get; set; }
        
        public string? Password { get; set; }
    }
}
