using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStoreBLLLibrary
{
    public class OrderService : IOrderService
    {
        private readonly IMenuService _menuService;
        private Dictionary<int, Order> _cart;
        private int _orderIdCounter = 100; 

        public OrderService(IMenuService menuService)
        {
            _menuService = menuService;
            _cart = new Dictionary<int, Order>();
        }
        Order order = new Order
        {
            OrderedItems = new List<Pizza>()
        };
        public void PlaceOrder()
        {
            IPaymentService paymentService = new PaymentService();
            if (_cart.Count == 0)
            {
                Console.WriteLine("Cart is empty. Please add pizzas before placing an order.");
               
            }

            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine() ?? String.Empty;

            Console.Write("Enter your contact information either email/mobile: ");
            string contactInfo = Console.ReadLine();
            Console.Write("Do you want delivery? (Y/N): ");
            bool isDelivery = Console.ReadLine().ToUpper() == "Y";
            string deliveryAddress = isDelivery ? GetDeliveryAddress() : "";
            SelectPizza();
            decimal totalAmount = CalculateTotalAmount(order,isDelivery);

           
            bool paymentSuccess = paymentService.ProcessPayment(totalAmount);

            if (paymentSuccess)
            {
                Order order = new Order
                {
                    Id = GenerateOrderId(),
                    CustomerName = customerName,
                    ContactInformation = contactInfo,
                    DeliveryAddress = deliveryAddress,
                    IsDeliveryNeededOrPickup = isDelivery,
                    OrderedItems = new List<Pizza>(_cart.SelectMany(o => o.Value.OrderedItems))
                };
                _cart.Add(order.Id, order);
                PrintOrderDetails(order);
                totalAmount = 0;
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

        private decimal CalculateTotalAmount(Order currentOrder, bool isDelivery)
        {
            decimal totalAmount = 0;

            foreach (var pizza in currentOrder.OrderedItems)
            {
                totalAmount += (decimal)pizza.Prices.GetValueOrDefault("SMALL");

            }

            if (isDelivery)
            {
                totalAmount += 150;
            }

            return totalAmount;
        }

        private void PrintOrderDetails(Order order)
        {
            Console.WriteLine("Order Details:");
            Console.WriteLine($"YOUR ORDER ID: {order.Id}");
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

        private int GenerateOrderId()
        {
            return ++_orderIdCounter;
        }

        public void AddToCart(Order order)
        {
            int orderId = GenerateOrderId();
            _cart.Add(orderId, order);
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
            double price = 0;
            while (true)
            {
                Console.Write("Select a pizza (enter its ID) or enter 0 to finish: ");
                int pizzaId = int.Parse(Console.ReadLine());

                if (pizzaId == 0)
                    break;

                Pizza selectedPizza = menu.Find(p => p.Id == pizzaId);
                if (selectedPizza == null)
                {
                    Console.WriteLine("Invalid pizza selection.");
                    continue;
                }

                Console.WriteLine("Available Sizes:");
                int i = 1;
                foreach (var size in selectedPizza.Prices.Keys)
                {
                    Console.WriteLine($"{i}\t:\t{size}");
                    i++;
                }

                Console.Write("Select a size: ");
                string selectedSize = Console.ReadLine().ToUpper();

                price+= selectedPizza.Prices[selectedSize];
                Console.WriteLine($"Price for {selectedSize} size of {selectedPizza.Name}: ${price}");

                order.OrderedItems.Add(selectedPizza);
            }
            AddToCart(order);

            price = 0;
        }


        public void ViewOrders()
        {
            Console.WriteLine("Orders:");
            if (_cart.Count == 0)
            {
                Console.WriteLine("No orders found in the cart.");
                return;
            }

            foreach (var order in _cart.Values)
            {
                Console.WriteLine($"Order ID: {order.Id}");
                Console.WriteLine($"Customer: {order.CustomerName}");
                Console.WriteLine("Ordered Items:");
                foreach (var pizza in order.OrderedItems)
                {
                    Console.WriteLine($"- {pizza.Name}");
                }
                Console.WriteLine("------------------");
            }
        }

        public void ClearOrders()
        {
            _cart.Clear();
            Console.WriteLine("Orders cleared successfully!");
        }
    }
}
