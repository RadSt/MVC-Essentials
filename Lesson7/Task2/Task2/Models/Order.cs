using System;
using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Выберите продукт")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Выберите покупателя")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Введите дату")]
        [DataType(DataType.Date,ErrorMessage = "Неверный формат даты")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Введите продукт")]
        public Product Product { get; set; }
        [Required(ErrorMessage = "Введите покупателя")]
        public Customer Customer { get; set; }
    }
}