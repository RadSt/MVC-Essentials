using System;

namespace Test3Task.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}