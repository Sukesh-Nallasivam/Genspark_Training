using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
