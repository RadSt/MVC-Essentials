using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage="Введите подтверждение пароля")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password",ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }
 
    }
}