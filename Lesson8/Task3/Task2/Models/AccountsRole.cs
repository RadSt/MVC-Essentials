using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test3Task.Models
{
    public class AccountsRole
    {
        [Required]
        [DisplayName("Номер")]
        public int UserId { get; set; }
        [Required]
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Роль")]
        public string[] Role { get; set; }
    }
}