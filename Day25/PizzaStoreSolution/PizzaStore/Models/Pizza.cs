namespace PizzaStore.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public IList<string> PizzaDescription { get; set; }
    }
}
