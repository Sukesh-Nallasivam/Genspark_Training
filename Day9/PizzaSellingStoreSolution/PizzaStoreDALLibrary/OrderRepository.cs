using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreDALLibrary
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders; // Assuming in-memory storage for simplicity

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public Order GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public Order Add(Order order)
        {
            order.Id = _orders.Any() ? _orders.Max(o => o.Id) + 1 : 1; 
            order.OrderDateTime = DateTime.Now;
            _orders.Add(order);
            return order;

        }

        public Order Update(Order updatedOrder)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == updatedOrder.Id);
            if (existingOrder != null)
            {
                existingOrder.CustomerName = updatedOrder.CustomerName;
                existingOrder.ContactInformation = updatedOrder.ContactInformation;
                existingOrder.OrderedItems = updatedOrder.OrderedItems;
                existingOrder.IsDeliveryNeededOrPickup = updatedOrder.IsDeliveryNeededOrPickup;
                existingOrder.DeliveryAddress = updatedOrder.DeliveryAddress;
            }
            else
            {
                throw new ArgumentException($"Order with ID {updatedOrder.Id} not found.");
            }
            return null;
        }

        public Order Delete(int id)
        {
            var orderToRemove = _orders.FirstOrDefault(o => o.Id == id);
            if (orderToRemove != null)
            {
                _orders.Remove(orderToRemove);
            }
            else
            {
                throw new ArgumentException($"Order with ID {id} not found.");
            }
            return null;
        }
        public List<Order> GetOrdersByCustomer(string customerName)
        {
            return _orders.Where(o => o.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _orders.Where(o => o.OrderDateTime >= startDate && o.OrderDateTime <= endDate).ToList();
        }

        public Order Get(int key)
        {
            throw new NotImplementedException();
        }
    }
}
