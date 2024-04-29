namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int NumberOfProductsInCart { get; set; }
        public double TotalAmount { get; set; }
        public List<string>? Products { get; set;}

    }
}
