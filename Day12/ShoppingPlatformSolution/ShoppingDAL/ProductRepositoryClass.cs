using ShoppingModelLibrary;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Product? GetByName(string Name)
        {
            Console.WriteLine("Product List:");
            foreach (Product product in ProductList)
            {
                Console.WriteLine($"Name: {product.ProductName}, ID: {product.ProductId}, " +
                                  $"Category: {product.ProductCategory}, Price: {product.ProductPrice}, " +
                                  $"Availability: {product.ProductAvailability}");
            }
            try
            {
                var item = (from Product s in ProductList
                            where s.ProductName.Contains(Name)
                            select s).FirstOrDefault();

                if (item != null)
                    return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving product by name: {ex.Message}");
            }
            return null;

        }
        public Dictionary<object, Product> GetAll()
        {
            var dictionary = ProductList.Cast<Product>().ToDictionary
                             (product => (object)product.ProductId, product => product);
            return dictionary;
        }

        public bool Update(Product _product)
        {
            try
            {
                // Find the product with the specified ID in the ProductList
                var productToUpdate = ProductList.OfType<Product>()
                                                  .FirstOrDefault(p => p.ProductId == _product.ProductId);

                // If the product is found, update its properties
                if (productToUpdate != null)
                {
                    // Update the properties of the found product
                    // For example:
                    productToUpdate.ProductName = _product.ProductName;
                    productToUpdate.ProductPrice = _product.ProductPrice;
                    productToUpdate.ProductCategory = _product.ProductCategory;
                    productToUpdate.ProductAvailability = _product.ProductAvailability;

                    // Optionally, you can perform additional update operations here

                    return true; // Return true to indicate successful update
                }
                else
                {
                    // If the product with the specified ID is not found
                    Console.WriteLine($"Product with ID {_product.ProductId} not found.");
                    return false; // Return false to indicate failure
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the update operation
                Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                return false; // Return false to indicate failure
            }
        }

    }
}
