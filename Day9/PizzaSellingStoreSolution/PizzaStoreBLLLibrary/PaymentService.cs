using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public class PaymentService : IPaymentService
    {
        public decimal CalculateTotalAmount(List<Pizza> orderedItems, bool isDeliveryNeededOrPickup)
        {
            decimal totalAmount = 0;

            foreach (var pizza in orderedItems)
            {
                totalAmount += (decimal)pizza.Prices["Medium"]; 
            }

            
            if (isDeliveryNeededOrPickup)
            {
                totalAmount += 5;
            }
            totalAmount *= 1.05m; 

            return totalAmount;
        }

        public bool ProcessPayment(decimal totalAmount)
        {
            Console.WriteLine("Make Payment");
            Console.WriteLine($"YOUR TOTAL AMOUNT : {totalAmount}");
            Console.WriteLine("You will be redirected to payment gateway....");
            bool result = false;
            //assumption
            Console.Write("Have you made payment (Y/N): ");
            bool choice = Console.ReadLine().ToUpper() == "Y";
            result = choice;
            return result;
        }

       
    }
}
