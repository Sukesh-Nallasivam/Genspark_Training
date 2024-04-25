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
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public string ProductCategory { get; set; } = String.Empty; 
        public int ProductAvailability { get; set; }

    }
}
