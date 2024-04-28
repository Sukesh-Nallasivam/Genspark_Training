using ShoppingBLL;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlatform
{
    public class MethodForProduct
    {
        
        readonly ProductService productService = new();
        public void ChoiceSelection()
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
                Console.WriteLine("6.Get All Prducts");
                Console.WriteLine("0.Go Back To Main Menu");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Moving To Main Menu");
                        break;
                    case 1:
                        AddProductUI();
                        break;
                    case 2:
                        UpdateProductUI();
                        break;
                    case 3:
                        RemoveProductUI();
                        break;
                    case 4:
                        GetProductsByNameUI();
                        break;
                    case 5:
                        GetProductsByCategoryUI();
                        break;
                    case 6:
                        GetAllProductsUI();
                        break;
                    //case 7:
                    //    program.MethodForProduct();
                    //    break;
                    default:
                        Console.WriteLine("Ooops!!! Wrong Selection.  Please Select Opton as follows");
                        break;
                }
            } while (choice != 0);
        }
        public void AddProductUI()
        {
            Product item = new();
            Console.WriteLine("You're Adding Product");
            Console.WriteLine("Enter Product Name");
            string ProductName = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = productService.GetProductByName(ProductName);
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
            productService.AddProduct(item);
        }
        public void UpdateProductUI()
        {
            Product item = new();
            Console.WriteLine("You're Updating a Product");
            Console.WriteLine("Enter Product Name");
            string ProductName = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = productService.GetProductByName(ProductName);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product not exists...............Try Again");
                //productService.PrintDetails(DuplicateVerification);
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
            productService.UpdateProduct(item);
        }
        public void RemoveProductUI()
        {
            Console.WriteLine("Enter product name to Remove");
            string Name=Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = productService.GetProductByName(Name);
            if(DuplicateVerification == null)
            {
                Console.WriteLine("Product Not found");
                return;
            }
            productService.RemoveProduct(DuplicateVerification);
        }
        public void GetProductsByNameUI()
        {
            Console.WriteLine("Enter product name to Find");
            string Name = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = productService.GetProductByName(Name);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product Not found");
                return;
            }
            productService.PrintDetails(DuplicateVerification);
        }
        public void GetProductsByCategoryUI()
        {
            Console.WriteLine("Enter product Category to Find");
            string Category = Console.ReadLine()?.ToUpper() ?? string.Empty;
            Product DuplicateVerification = productService.GetProductByCategories(Category);
            if (DuplicateVerification == null)
            {
                Console.WriteLine("Product Not found");
                return;
            }
            productService.PrintDetails(DuplicateVerification);
        }
        public void GetAllProductsUI()
        {
            Dictionary<object, Product> allProducts = productService.GetAllProduct();
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
