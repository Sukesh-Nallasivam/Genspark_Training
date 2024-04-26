using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingBLL
{
    internal interface ICart
    {
        void AddItemsToCart();
        void UpdateItemsInCart(IEnumerable<ICart> items);
        void DeleteItemsInCart(Cart items);
        Cart GetCart(int CustomerId);

    }
}
