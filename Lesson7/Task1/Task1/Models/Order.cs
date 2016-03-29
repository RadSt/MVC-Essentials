using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Task1.Models
{
    public class Order
    {

        [Required(ErrorMessage = "Поле обязательно для заполнения")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"/.+@.+\..+/i",ErrorMessage = "Введите емаил верного формата")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MustBeTrue(ErrorMessage = "Вы не согласились с условиями использования")]
        public bool TermsAccepted { get; set; }
    }
}