using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Product
    {
        public string ProductName { get; set; } = String.Empty;
        public string ProductId { get; set; } = String.Empty;
        public double ProductPrice { get; set; }
        public string ProductCategory { get; set; } = String.Empty; 
        public string ProductAvailability { get; set; } = String.Empty;

    }
}
