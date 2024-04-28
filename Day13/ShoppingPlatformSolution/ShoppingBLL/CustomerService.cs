using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLL
{
    public class CustomerService : ICart, ICustomer
    {
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddItemsToCart()
        {
            
        }

        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteItemsInCart(Cart items)
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Cart GetDetailsOfCart(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateItemsInCart(IEnumerable<ICart> items)
        {
            throw new NotImplementedException();
        }
    }
}
