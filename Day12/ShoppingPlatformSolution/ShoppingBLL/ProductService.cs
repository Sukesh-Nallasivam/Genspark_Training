using ShoppingModelLibrary;
using ShoppingDAL;
namespace ShoppingBLL
{
    public class ProductService : IProduct
    {
        private readonly ProductRepositoryClass repositoryClass;

        public ProductService()
        {
            repositoryClass = new ProductRepositoryClass();
        }
        List<Product> products = new List<Product>();
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

        public Product GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByCategories(string category)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public string RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
        
        public void PrintDetails(Product product)
        {

            Console.WriteLine($"Name\t:\t{product.ProductName}");
            Console.WriteLine($"Id\t:\t{product.ProductId}");
            Console.WriteLine($"Price\t:\t{product.ProductPrice}");
            Console.WriteLine($"Category\t:\t{product.ProductCategory}");
            Console.WriteLine($"Product(s) left in Warehouse\t:\t{product.ProductAvailability}");
        }
    }
}
