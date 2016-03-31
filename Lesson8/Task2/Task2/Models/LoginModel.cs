using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name="Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}