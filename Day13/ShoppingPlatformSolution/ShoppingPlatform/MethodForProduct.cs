using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingBLL;
using ShoppingModelLibrary;

namespace ShoppingPlatform
{
    public class MethodForProduct
    {
        readonly ProductService productService = new();

        public async Task ChoiceSelection()
        {
            int choice;
            do
            {
                Console.WriteLine("Select choice for product Service");
                Console.WriteLine("1.Add Products");
                Console.WriteLine("2.Update Products");
                Console.WriteLine("3.Delete Products");
                Console.WriteLine("4.Get Products by Name");
                Console.WriteLine("5.Get Products by their Category");
                Console.WriteLine("6.Get All Products");
                Console.WriteLine("0.Go Back To Main Menu");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Moving To Main Menu");
                        break;
                    case 1:
                        await AddProductUI();
                        break;
                    case 2:
                        await UpdateProductUI();
                        break;
                    case 3:
                        await RemoveProductUI();
                        break;
                    case 4:
                        await GetProductsByNameUI();
                        break;
                    case 5:
                        await GetProductsByCategoryUI();
                        break;
                    case 6:
                        await GetAllProductsUI();
                        break;
                    default:
                        Console.WriteLine("Ooops!!! Wrong Selection.  Please Select Option as follows");
                        break;
                }
            } while (choice != 0);
        }

        public async Task AddProductUI()
        {
            Product item = new();
            Console.WriteLine("You're Adding Product");
            Console.WriteLine("Enter Product Name");
            string ProductName = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = await productService.GetProductByNameAsync(ProductName);
            if (DuplicateVerification != null)
            {
                Console.WriteLine("Product already exists");
                productService.PrintDetails(DuplicateVerification);
                return;
            }
            Console.WriteLine("Enter Total Quantity");
            int ProductAvailability = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Category");
            string ProductCategory = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Enter Price of the Product");
            double ProductPrice = Convert.ToInt32(Console.ReadLine());
            item.ProductName = ProductName;
            item.ProductAvailability = ProductAvailability;
            item.ProductCategory = ProductCategory;
            item.ProductPrice = ProductPrice;
            await productService.AddProductAsync(item); // Await the asynchronous method
        }

        public async Task UpdateProductUI()
        {
            Product item = new();
            Console.WriteLine("You're Updating a Product");
            Console.WriteLine("Enter Product Name");
            string ProductName = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = await productService.GetProductByNameAsync(ProductName);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product not exists...............Try Again");
                return;
            }
            Console.WriteLine($"Product {DuplicateVerification.ProductName} exists with ID as {DuplicateVerification.ProductId}");
            Console.WriteLine($"Enter Product Name instead of {DuplicateVerification.ProductName}\t:\t");
            ProductName = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Console.WriteLine($"Enter Total Quantity instead of {DuplicateVerification.ProductAvailability}\t:\t");
            int ProductAvailability = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter Product Category instead of {DuplicateVerification.ProductCategory}\t:\t");
            string ProductCategory = Console.ReadLine() ?? String.Empty;
            Console.WriteLine($"Enter Price of the Product instead of {DuplicateVerification.ProductPrice}\t:\t");
            double ProductPrice = Convert.ToInt32(Console.ReadLine());
            item.ProductId = DuplicateVerification.ProductId;
            item.ProductName = ProductName;
            item.ProductAvailability = ProductAvailability;
            item.ProductCategory = ProductCategory;
            item.ProductPrice = ProductPrice;
            await productService.UpdateProductAsync(item); // Await the asynchronous method
        }

        public async Task RemoveProductUI()
        {
            Console.WriteLine("Enter product name to Remove");
            string Name = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = await productService.GetProductByNameAsync(Name);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product Not found");
                return;
            }
            await productService.RemoveProductAsync(DuplicateVerification); // Await the asynchronous method
        }

        public async Task GetProductsByNameUI()
        {
            Console.WriteLine("Enter product name to Find");
            string Name = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = await productService.GetProductByNameAsync(Name);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product Not found");
                return;
            }
            productService.PrintDetails(DuplicateVerification);
        }

        public async Task GetProductsByCategoryUI()
        {
            Console.WriteLine("Enter product Category to Find");
            string Category = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = await productService.GetProductByCategoriesAsync(Category);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product Not found");
                return;
            }
            productService.PrintDetails(DuplicateVerification);
        }

        public async Task GetAllProductsUI()
        {
            Dictionary<object, Product> allProducts = await productService.GetAllProductAsync();
            if (allProducts != null && allProducts.Count > 0)
            {
                Console.WriteLine("All Products:");
                foreach (var products in allProducts)
                {
                    Product product = products.Value;
                    productService.PrintDetails(product);
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
        }
    }
}
