using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;

namespace PizzaStoreBLLLibrary
{
    public class OrderService : IOrderService
    {
        private readonly IMenuService _menuService;
        private List<Order> _cart;
        //private List<Order> orders;


        public OrderService(IMenuService menuService)
        {
            _menuService = menuService;
            _cart = new List<Order>();
        }

        public void PlaceOrder()
        {
            IPaymentService paymentService = new PaymentService();
            if (_cart.Count == 0)
            {
                Console.WriteLine("Cart is empty. Please add pizzas before placing an order.");
            }

            // Gather customer details
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter your contact information: ");
            string contactInfo = Console.ReadLine();
            Console.Write("Do you want delivery? (Y/N): ");
            bool isDelivery = Console.ReadLine().ToUpper() == "Y";
            string deliveryAddress = isDelivery ? GetDeliveryAddress() : "";
            SelectPizza();
            decimal totalAmount = CalculateTotalAmount();

            // Process payment
            bool paymentSuccess = paymentService.ProcessPayment(totalAmount);

            if (paymentSuccess)
            {
                Order order = new Order
                {
                    CustomerName = customerName,
                    ContactInformation = contactInfo,
                    DeliveryAddress = deliveryAddress,
                    IsDeliveryNeededOrPickup = isDelivery,
                    OrderedItems = new List<Pizza>(_cart.SelectMany(o => o.OrderedItems))
                };

                PrintOrderDetails(order);

                
            }
            else
            {
                Console.WriteLine("Payment failed. Order not placed");
            }
        }

        private string GetDeliveryAddress()
        {
            Console.Write("Enter delivery address: ");
            return Console.ReadLine();
        }

        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (var order in _cart)
            {
                foreach (var pizza in order.OrderedItems)
                {
                    foreach (var price in pizza.Prices.Values)
                    {
                        totalAmount += (decimal)price;
                    }
                }
            }

            return totalAmount;
        }

        private void PrintOrderDetails(Order order)
        {
            Console.WriteLine("Order Details:");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"Contact Information: {order.ContactInformation}");
            Console.WriteLine($"Delivery Address: {order.DeliveryAddress}");
            Console.WriteLine($"Is Delivery: {(order.IsDeliveryNeededOrPickup ? "Yes" : "No")}");
            Console.WriteLine("Ordered Items:");
            foreach (var pizza in order.OrderedItems)
            {
                Console.WriteLine($"- {pizza.Name}");
            }

            Console.WriteLine("Order placed successfully.");
        }

        public void AddToCart(Order order)
        {
            _cart.Add(order);
            Console.WriteLine("Pizza added to cart.");
        }

        public void SelectPizza()
        {
            List<Pizza> menu = _menuService.GetMenu();
            Console.WriteLine("Available Pizzas:");
            foreach (var pizza in menu)
            {
                Console.WriteLine($"{pizza.Id}. {pizza.Name}");
            }

            Console.Write("Select a pizza (enter its ID): ");
            int pizzaId = int.Parse(Console.ReadLine());

            Pizza selectedPizza = menu.Find(p => p.Id == pizzaId);
            if (selectedPizza == null)
            {
                Console.WriteLine("Invalid pizza selection.");
                return;
            }

            Console.WriteLine("Available Sizes:");
            int i = 1;
            foreach (var size in selectedPizza.Prices.Keys)
            {
                Console.WriteLine($"{i}\t:\t{size}");
            }

            Console.Write("Select a size: ");
            string selectedSize = Console.ReadLine().ToUpper();

            double price = selectedPizza.Prices[selectedSize];
            Console.WriteLine($"Price for {selectedSize} size of {selectedPizza.Name}: ${price}");

            // Add the selected pizza to the cart
            Order order = new Order
            {
                OrderedItems = new List<Pizza> { selectedPizza }
            };
            AddToCart(order);
        }
        public void ViewOrders()
        {
            Console.WriteLine("Orders:");
            foreach (var order in _cart)
            {
                Console.WriteLine($"Customer: {order.CustomerName}, Total Cost: {order.OrderedItems}");
            }
        }
        public void ClearOrders()
        {
            _cart.Clear();
            Console.WriteLine("Orders cleared successfully!");
        }
    }
}
