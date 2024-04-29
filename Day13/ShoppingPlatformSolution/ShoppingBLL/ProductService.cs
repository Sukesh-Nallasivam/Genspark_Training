using ShoppingModelLibrary;
using ShoppingDAL;
using System.Xml.Linq;

namespace ShoppingBLL
{
    public class ProductService : IProduct
    {
        private readonly ProductRepositoryClass repositoryClass;

        public ProductService()
        {
            repositoryClass = new ProductRepositoryClass();
        }
        
        int ProductId;
        int GenerateProductId()
        {
            if(ProductId == 0)
            {
                return ProductId = 001;
            }
            return ++ProductId;
        }
        public string AddProduct(Product product)
        {
            try
            {
                product.ProductId = GenerateProductId();
                repositoryClass.Add(product);
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                ProductId -= 1;
                return $"Cannot be added. {ex.Message}";
            }
            
        }

        public Product? GetProductByCategories(string category)
        {
            return repositoryClass.GetByName(category);
        }

        public Product? GetProductByName(string name)
        {
            return repositoryClass.GetByName(name);
        }

        public string RemoveProduct(Product product)
        {
            try
            {
                repositoryClass.Delete(product);
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to delete");
            }
            return "Try Again";
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                if (repositoryClass.Update(product))
                {
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Updating: {ex.Message}");
                return false;
            }
        }


        public void PrintDetails(Product product)
        {

            Console.WriteLine($"Name\t\t:\t{product.ProductName}");
            Console.WriteLine($"Id\t\t:\t{product.ProductId}");
            Console.WriteLine($"Price\t\t:\t{product.ProductPrice}");
            Console.WriteLine($"Category\t:\t{product.ProductCategory}");

            if (product.ProductAvailability > 0)
            {
                Console.WriteLine("In Stock");
                Console.WriteLine($"Product(s) left in Warehouse\t:\t{product.ProductAvailability}");
            }
            else
            {
                Console.WriteLine("Out of stock");
            }
        }

        public async Task<Dictionary<object, Product>> GetAllProductAsync()
        {
            try
            {
                return await repositoryClass.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all products asynchronously: {ex.Message}");
                return null;
            }
        }
    }
}
