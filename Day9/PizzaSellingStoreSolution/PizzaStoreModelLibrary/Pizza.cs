namespace PizzaStoreModelLibrary
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public Dictionary<string, double> Prices { get; set; }
        public bool IsAvailable { get; set; }
    }
}
