using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Models
{
    public class UserAccount
    {
        public int UserId { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? PasswordHashKey { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public string status { get; set; } = "false";
    }
}
