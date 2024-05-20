using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLoginTraining1705.Models
{
    public class Security
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public User User { get; set;}
    }
}
