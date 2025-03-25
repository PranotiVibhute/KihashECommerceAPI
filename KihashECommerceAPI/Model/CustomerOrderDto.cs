namespace KihashECommerceAPI.Model
{
    public class CustomerOrderDto
    {
        public int? OrderId { get; set; }
        public string?  CustomerName { get; set; }

        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
