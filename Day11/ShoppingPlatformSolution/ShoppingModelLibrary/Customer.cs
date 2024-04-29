using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer
    {
        public string CustomerName { get; set; } = String.Empty;
        public int CustomerId { get; set; }
        public double CustomerMobile { get; set; }
        public string CustomerEmail { get; set; } = String.Empty;
        public string CustomerAddress { get; set; } = String.Empty;
    }
}
