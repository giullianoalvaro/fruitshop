using FruitShop.Data.Entity;
using FruitShop.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FruitShop.App
{
    class Program
    {
        #region "Private Services"
        private static ProductService productService = new ProductService();
        private static bool stopApplication = false;
        #endregion

        private static void Main(string[] args)
        {
            Console.WriteLine(":: Welcome a fruit shop ::");
            Console.WriteLine("\n\r");

            while (!stopApplication)
            {
                SelectingAnOption();
            }

            Console.WriteLine("Application will be terminated.");
            Console.ReadKey();
        }

        #region "Methods
        /// <summary>
        /// Select an option
        /// </summary>
        private static void SelectingAnOption()
        {
            Console.WriteLine("Enter the option below to continue:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Buy a product");
            Console.WriteLine("2. List the products");
            Console.WriteLine("3. Check my purchase");

            //Input validation
            try
            {
                if (int.TryParse(Console.ReadLine(), out var userInput))
                {
                    switch (userInput)
                    {
                        //1.Buy a product
                        case 1:
                            BuyProduct();
                            break;
                        //2. List the products
                        case 2:
                            ListProducts();
                            break;
                        //3. List of products purchased
                        case 3:
                            ProductsPurchased();
                            break;
                        //Exit application
                        default:
                            stopApplication = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Invalid input
                stopApplication = true;
            }
        }

        /// <summary>
        /// Return list of products
        /// </summary>
        private static void ListProducts()
        {
            var productList = productService.ListProducts();

            if (!productList.Any())
            {
                //Invalid input
                Console.WriteLine("The product list is empty");
            }

            foreach (var item in productList)
            {
                Console.WriteLine($"Id: {item.ProductId} | Product Name: {item.Name} | Price: {item.Price:C}");
            }
        }

        /// <summary>
        /// Buy Product
        /// </summary>
        private static void BuyProduct()
        {
            try
            {
                Console.WriteLine("Enter the product id:");
                if (int.TryParse(Console.ReadLine(), out int ProductId))
                {
                    Console.WriteLine("Enter the quantity of the product:");
                    if (int.TryParse(Console.ReadLine(), out int QuantityProduct))
                    {
                        productService.BuyProduct(ProductId, QuantityProduct);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// list of products purchased
        /// </summary>
        private static void ProductsPurchased()
        {
            try
            {
                Console.WriteLine(":: List of products purchased ::");
                var purchased = productService.ListProductsPurchased();
                if (!purchased.Any())
                {
                    Console.WriteLine("No product was purchased.");
                }

                var totalPrice = purchased.Sum(x => x.TotalProduct);
                foreach (var item in purchased)
                {
                    Console.WriteLine($"Id: {item.Product.ProductId} | Product: {item.Product.Name} | Price: {item.Product.Price} | Quantity: {item.Quantity} | Total Product Price: {item.TotalProduct:C}");
                }
                Console.WriteLine("-------------");
                Console.WriteLine($"Total: {totalPrice:C}");
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
