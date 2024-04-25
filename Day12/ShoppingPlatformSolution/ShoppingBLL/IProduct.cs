using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingBLL
{
    internal interface IProduct
    {
        Product GetProductByCategories(string category);
        string AddProduct (Product product);
        Product GetProductByName(string name);
        Product UpdateProduct (Product product);
        string RemoveProduct(Product product);
        Product GetAllProduct();
    }
}
