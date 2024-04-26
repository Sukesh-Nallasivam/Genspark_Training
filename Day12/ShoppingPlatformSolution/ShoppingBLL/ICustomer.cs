using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;
using ShoppingDAL;

namespace ShoppingBLL
{
    internal interface ICustomer
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        Cart GetDetailsOfCart(int CustomerId);


    }
}
