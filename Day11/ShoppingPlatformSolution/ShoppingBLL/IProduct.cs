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
        string GetProductByCategories(Product category);
        string AddProduct (Product product);
        Product GetProductByName(string name);
        Product UpdateProductPrice (Product product);
        Product RemoveProduct(Product product);
        Product GetAllProduct();
    }
}
