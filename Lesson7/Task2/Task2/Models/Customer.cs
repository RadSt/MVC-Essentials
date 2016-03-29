using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
         [Required(ErrorMessage = "Введите имя покупателя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Введите емаил")]
        [RegularExpression(@"",ErrorMessage = "Введите верную почту")]
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}