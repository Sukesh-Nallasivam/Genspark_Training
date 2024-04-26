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
        void DeleteCustomer(int id);
        Customer GetCustomerInfoByName(string Name);
        Customer GetCustomerById(int id);



    }
}
