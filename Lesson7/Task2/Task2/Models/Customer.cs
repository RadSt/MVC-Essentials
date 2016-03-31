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
        [RegularExpression(@"(?i)\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Введите верный формат ящика")]
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}