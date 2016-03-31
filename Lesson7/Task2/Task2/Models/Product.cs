using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите цену")]
        [DataType(DataType.Currency,ErrorMessage = "Неверный форма цены")]
        public decimal Price { get; set; }
    }
}