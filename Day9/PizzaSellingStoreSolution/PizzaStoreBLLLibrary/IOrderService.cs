using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public interface IOrderService
    {
        public void PlaceOrder(string customerName, string contactInfo, string deliveryAddress, bool isDelivery, List<Pizza> orderedItems)
        {
            PrintOrderDetails(customerName, contactInfo, deliveryAddress, isDelivery, orderedItems);
        }

        void PlaceOrder(Order order)
        {
            //PrintOrderDetails();
            Console.WriteLine("Order Details:");

        }

        private void PrintOrderDetails(string customerName, string contactInfo, string deliveryAddress, bool isDelivery, List<Pizza> orderedItems)
        {
            Console.WriteLine("Order Details:");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Contact Information: {contactInfo}");
            Console.WriteLine($"Delivery Address: {deliveryAddress}");
            Console.WriteLine($"Is DeliveryNeeded: {(isDelivery ? "Yes" : "No")}");
            Console.WriteLine("Ordered Items:");
            foreach (var pizza in orderedItems)
            {
                Console.WriteLine($"- {pizza.Name}");
            }
            Console.WriteLine("Order placed successfully.");
        }
        
    }
}
