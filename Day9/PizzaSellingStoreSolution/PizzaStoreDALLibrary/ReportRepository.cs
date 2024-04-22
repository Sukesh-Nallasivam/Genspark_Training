using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreDALLibrary
{
    public class ReportRepository : IReportRepository
    {

        //sales reports, inventory status reports, delivery performance reports
        private List<Order> _orders;

        public ReportRepository()
        {
            _orders = new List<Order>
            {
                new Order { Id = 1, CustomerName = "A", OrderDateTime = DateTime.Now.AddDays(-5), IsDeliveryNeededOrPickup = true, DeliveryAddress = "123 MNC St", OrderedItems = new List<Pizza>() },
                new Order { Id = 2, CustomerName = "B", OrderDateTime = DateTime.Now.AddDays(-3), IsDeliveryNeededOrPickup = false, DeliveryAddress = "123 ABC st", OrderedItems = new List<Pizza>() },
                
            };

        }

        public void GenerateDeliveryPerformanceReport(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine("Delivery Performance Report..");
        }

        public void GenerateInventoryStatusReport()
        {
            Console.WriteLine("Inventory Status Report:");
            Console.WriteLine("Currently Available Pizzas:");
            
        }

        public void GenerateSalesReport(DateTime startDate, DateTime endDate)
        {
            var ordersInDateRange = _orders.FindAll(order => order.OrderDateTime >= startDate && order.OrderDateTime <= endDate);
            decimal totalSales = 0;
            foreach (var order in ordersInDateRange)
            {
                foreach (var pizza in order.OrderedItems)
                {
                    foreach (var price in pizza.Prices.Values)
                    {
                        totalSales += (decimal)price; 
                    }
                }
            }
            Console.WriteLine($"Sales Report for {startDate.ToShortDateString()} to {endDate.ToShortDateString()}:");
            Console.WriteLine($"Total Sales: {totalSales:C2}");
        }
    }
}
