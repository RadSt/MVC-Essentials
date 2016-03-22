using System.Collections.Generic;
using System.Web.Mvc;

namespace Task3.Models
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}