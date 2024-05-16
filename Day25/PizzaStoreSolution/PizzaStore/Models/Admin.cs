namespace PizzaStore.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; } = "admin";
        public byte[]? AdminPassword { get; set; }
        
    }
}
