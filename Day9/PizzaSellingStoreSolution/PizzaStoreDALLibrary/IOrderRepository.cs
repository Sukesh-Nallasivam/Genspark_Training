using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaStoreModelLibrary;

namespace PizzaStoreDALLibrary
{
    public interface IOrderRepository:IRepository<int,Order>
    {
        List<Order> GetOrdersByCustomer(string customerName);
        List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
    }
}
