using System;

namespace Task3.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateTime { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}