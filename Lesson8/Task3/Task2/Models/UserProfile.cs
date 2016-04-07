using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test3Task.Models
{
    [Table("UserProfile")] 
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        [DisplayName("Номер")]
        public int UserId { get; set; }
        [Required]
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }

    }
}