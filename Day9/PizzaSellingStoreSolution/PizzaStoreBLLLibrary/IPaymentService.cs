using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public interface IPaymentService
    {
        decimal CalculateTotalAmount(List<Pizza> orderedItems, bool isDeliveryNeededOrPickup);
        bool ProcessPayment(decimal totalAmount);
    }
}
