using System.ComponentModel.DataAnnotations;

namespace UserLoginTraining1705.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool AcitiveStatus { get; set; } = true;
       
    }
}
