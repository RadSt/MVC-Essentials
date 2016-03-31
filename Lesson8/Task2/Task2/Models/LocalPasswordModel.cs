using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class LocalPasswordModel
    {
        [Required(ErrorMessage = "Введите старый пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [Display(Name="Новый пароль")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Введите новый пароль для подтверждения")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}