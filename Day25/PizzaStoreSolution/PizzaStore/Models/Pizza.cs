namespace PizzaStore.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; } = string.Empty;
        public string PizzaDescription { get; set; } = string.Empty;
        public bool AvailabilityStatus { get; set; } = false;
        public int StockCount { get; set; } 
    }
}
