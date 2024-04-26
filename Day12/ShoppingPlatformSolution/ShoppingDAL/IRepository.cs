using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL
{
    public interface IRepository<K,T> where T : class
    {
        Dictionary<object,T> GetAll();
        void Add(T item);
        bool Update(T item);
        T Delete(T item);
        T Get(K key);

    }
}
