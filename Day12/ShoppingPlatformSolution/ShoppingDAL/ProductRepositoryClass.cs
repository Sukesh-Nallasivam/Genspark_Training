using ShoppingModelLibrary;
using System.Collections;

namespace ShoppingDAL
{
    public class ProductRepositoryClass : IRepository<int, Product>
    {
        private readonly ArrayList ProductList;
        public ProductRepositoryClass()
        {
            ProductList = new ArrayList();
        }
        public void Add(Product item)
        {
            ProductList.Add(item);
        }

        public Product Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int key)
        {
            throw new NotImplementedException();
        }

        public Dictionary<object, Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product Update(int key)
        {
            throw new NotImplementedException();
        }
    }
}
