using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;
using ShoppingBLL;

namespace ShoppingPlatform
{
    internal class MethodForCustomer
    {
        readonly CustomerService customerService;
        
        public MethodForCustomer()
        {
            customerService = new CustomerService();
        }
        public void AddCustomer(Customer customer)
        {
            customerService.AddCustomer(customer);
        }
        public void RemoveCustomer(Customer customer)
        {
            customerService.DeleteCustomer(customer);
        }
        public void GetCustomer(int id)
        {
            customerService.GetCustomerById(id);
        }
        public void UpdateCustomer(Customer customer)
        {
            customerService.UpdateCustomer(customer);
        }
        public void GetProduct()
        {
            ProductService productService = new ProductService();
            productService.GetAllProduct();
            customerService.AddItemsToCart();
        }
    }
}
