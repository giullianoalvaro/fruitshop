using FruitShop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitShop.Services.Services
{
    public class ProductService : IDisposable
    {
        #region "Private properties
        //Organizing Products in a list
        private readonly List<Product> ProductsList;

        //Organizing purchase list
        private readonly List<Purchase> PurchaseList = new List<Purchase>();
        #endregion

        public ProductService()
        {
            ProductsList = new List<Product>
            {
                new Product(1, "Pears", 0.75),
                new Product(2, "Apples", 0.9),
                new Product(3, "Oranges", 1)
            };
        }

        #region "Methods"
        /// <summary>
        /// List the Products
        /// </summary>
        /// <returns>Returns the list of products</returns>
        public List<Product> ListProducts()
        {
            return ProductsList.ToList();
        }

        /// <summary>
        /// List of products purchased
        /// </summary>
        /// <returns>Returns the list of products purchased</returns>
        public List<Purchase> ListProductsPurchased()
        {
            return PurchaseList.ToList();
        }

        /// <summary>
        /// Buy a product
        /// </summary>
        /// <param name="Name">Name of product</param>
        /// <param name="Price">Price of product</param>
        /// <returns>True if it was successful and false for it was not possible</returns>
        public void BuyProduct(int id, int quantity)
        {
            var product = ProductsList.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                PurchaseList.Add(new Purchase
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
