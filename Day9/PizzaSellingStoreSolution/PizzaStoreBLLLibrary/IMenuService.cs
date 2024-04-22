using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public interface IMenuService
    {
        List<Pizza> GetMenu();
        void AddPizza(Pizza pizza);
        void UpdatePizza(Pizza pizza);
        void RemovePizza(int pizzaId);
    }
}
