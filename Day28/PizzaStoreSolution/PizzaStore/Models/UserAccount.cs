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

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string status { get; set; } = "false";
        internal byte[] PasswordSalt;
    }
}
