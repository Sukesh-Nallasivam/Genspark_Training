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

        public Dictionary<object, Product> GetAllProduct()
        {
            try
            {
                var allProducts = repositoryClass.GetAll();
                if (allProducts != null)
                {
                    return allProducts;
                }
                else
                {
                    Console.WriteLine("No products found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving all products: {ex.Message}");
            }
            return null;
        }

        public Product GetProductByCategories(string category)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductByName(string name)
        {
            return repositoryClass.GetByName(name);
        }

        public string RemoveProduct(Product product)
        {
            throw new NotImplementedException();
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
        //public void PrintDetails(Product product)
        //{
        //    // Define the format for each column
        //    string format = "|{0,-15}|{1,-5}|{2,-10}|{3,-15}|{4,-14}|";

        //    // Print the header row
        //    Console.WriteLine("+" + new string('-', 15) + "+" + new string('-', 5) + "+" + new string('-', 10) + "+" + new string('-', 15) + "+" + new string('-', 14) + "+");
        //    Console.WriteLine(string.Format(format, "Name", "Id", "Price", "Category", "Availability"));
        //    Console.WriteLine("+" + new string('-', 15) + "+" + new string('-', 5) + "+" + new string('-', 10) + "+" + new string('-', 15) + "+" + new string('-', 14) + "+");

        //    // Print the product details
        //    Console.WriteLine(string.Format(format, product.ProductName, product.ProductId, product.ProductPrice, product.ProductCategory, (product.ProductAvailability > 0 ? product.ProductAvailability.ToString() : "Out of stock")));

        //    // Print the bottom border
        //    Console.WriteLine("+" + new string('-', 15) + "+" + new string('-', 5) + "+" + new string('-', 10) + "+" + new string('-', 15) + "+" + new string('-', 14) + "+");
        //}

    }
}
