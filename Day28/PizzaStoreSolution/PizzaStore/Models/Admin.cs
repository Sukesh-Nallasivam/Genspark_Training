using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; } = "admin";
        public byte[]? AdminPasswrd { get; set; }
        
    }
}
