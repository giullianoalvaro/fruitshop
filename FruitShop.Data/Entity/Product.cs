namespace FruitShop.Data.Entity
{
    /// <summary>
    /// Entity of products
    /// </summary>
    public class Product
    {
        #region "Properties"
        public int ProductId { get; set; }
        //Name of product
        public string Name { get; set; }
        //Price of product
        public double Price { get; set; }
        #endregion

        public Product()
        {

        }

        public Product(int id, string name, double price)
        {
            Name = name;
            Price = price;
            ProductId = id;
        }
    }
}
