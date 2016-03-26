﻿using System.Collections.Generic;

namespace Test3Task.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}