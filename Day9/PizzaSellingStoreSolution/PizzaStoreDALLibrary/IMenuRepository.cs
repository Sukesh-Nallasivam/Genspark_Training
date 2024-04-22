using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaStoreModelLibrary;

namespace PizzaStoreDALLibrary
{
    public interface IMenuRepository:IRepository<int,Pizza>
    {
        //Any method can be added specific if necessary....
    }
}
