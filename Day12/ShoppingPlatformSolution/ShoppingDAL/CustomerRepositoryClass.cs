using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingDAL
{
    internal class CustomerRepositoryClass : IRepository<int, Customer>
    {
        public void Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public string Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int key)
        {
            throw new NotImplementedException();
        }

        public Dictionary<object, Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
