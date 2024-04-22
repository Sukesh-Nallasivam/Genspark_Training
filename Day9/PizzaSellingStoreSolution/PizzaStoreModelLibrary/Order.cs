using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreModelLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ContactInformation { get; set; }
        public List<Pizza> OrderedItems { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool IsDeliveryNeededOrPickup { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
