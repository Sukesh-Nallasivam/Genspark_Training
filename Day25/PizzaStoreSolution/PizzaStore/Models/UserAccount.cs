using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Models
{
    public class UserAccount
    {

        [Key]
        public int UserId { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? PasswordHashKey { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public string status { get; set; } = "true";
        internal byte[] PasswordSalt;
    }
}
