using PizzaStoreModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreDALLibrary
{
    public class MenuRepository:IMenuRepository
    {
        readonly List<Pizza> _menu;
        public MenuRepository()
        {
            _menu = new List<Pizza>();
        }
        public List<Pizza> GetAll()
        {
            return _menu;
        }

        public Pizza GetById(int id)
        {
            return _menu.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Pizza pizza)
        {
            pizza.Id = _menu.Any() ? _menu.Max(p => p.Id) + 1 : 1; // Generate unique ID
            _menu.Add(pizza);
        }

        public void Update(Pizza updatedPizza)
        {
            var existingPizza = _menu.FirstOrDefault(p => p.Id == updatedPizza.Id);
            if (existingPizza != null)
            {
                
                existingPizza.Name = updatedPizza.Name;
                existingPizza.Ingredients = updatedPizza.Ingredients;
                existingPizza.Prices = updatedPizza.Prices;
                existingPizza.IsAvailable = updatedPizza.IsAvailable;
                
            }
            else
            {
                throw new ArgumentException($"Pizza with ID {updatedPizza.Id} not found.");
            }
        }

        public void Delete(int id)
        {
            var pizzaToRemove = _menu.FirstOrDefault(p => p.Id == id);
            if (pizzaToRemove != null)
            {
                _menu.Remove(pizzaToRemove);
            }
            else
            {
                throw new ArgumentException($"Pizza with ID {id} not found.");
            }
        }

        public Pizza Get(int key)
        {
            throw new NotImplementedException();
        }

        Pizza IRepository<int, Pizza>.Add(Pizza item)
        {
            throw new NotImplementedException();
        }

        Pizza IRepository<int, Pizza>.Update(Pizza item)
        {
            throw new NotImplementedException();
        }

        Pizza IRepository<int, Pizza>.Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}
