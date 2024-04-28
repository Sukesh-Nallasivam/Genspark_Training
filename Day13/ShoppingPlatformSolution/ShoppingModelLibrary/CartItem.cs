using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    internal class CartItem
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }=String.Empty;
        public Dictionary<string, int>? ProductAndCount { get; set; }
    }
}
