using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;

namespace PizzaStoreBLLLibrary
{
    public class MenuService : IMenuService
    {
        private List<Pizza> _menu;

        public MenuService()
        {
           
            _menu = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Margherita", Prices = new Dictionary<string, double> { { "SMALL", 500.00 }, { "MEDIUM", 600.00 }, { "LARGE", 650.00} } },
                new Pizza { Id = 2, Name = "Pepperoni", Prices = new Dictionary<string,double> { { "SMALL", 550.00 }, { "MEDIUM", 700.00}, { "LARGE", 750.00 } } },
                
            };
        }

        public List<Pizza> GetMenu()
        {
            
            foreach (var pizza in _menu)
            {
                Console.WriteLine($"ID: {pizza.Id}, Name: {pizza.Name}, Prices: {string.Join(", ", pizza.Prices)}");
            }
            return _menu;
        }

        public void AddPizza(Pizza pizza)
        {
            
            _menu.Add(pizza);
        }

        public void UpdatePizza(Pizza pizza)
        {
            
            var existingPizza = _menu.Find(p => p.Id == pizza.Id);
            if (existingPizza != null)
            {
                existingPizza.Name = pizza.Name;
                existingPizza.Prices = pizza.Prices;
                
            }
            else
            {
                Console.WriteLine($"Pizza with ID {pizza.Id} not found.");
            }
        }

        public void RemovePizza(int pizzaId)
        {
            
            var pizzaToRemove = _menu.Find(p => p.Id == pizzaId);
            if (pizzaToRemove != null)
            {
                _menu.Remove(pizzaToRemove);
            }
            else
            {
                Console.WriteLine($"Pizza with ID {pizzaId} not found.");
            }
        }
    }
}
