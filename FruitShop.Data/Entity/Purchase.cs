namespace FruitShop.Data.Entity
{
    /// <summary>
    /// Entity of purchase
    /// </summary>
    public class Purchase
    {
        #region "Properties"
        //Product
        public Product Product { get; set; }
        //Product Quantity
        public int Quantity { get; set; }
        //Total Product Value
        public double TotalProduct => Product != null ? Product.Price * Quantity : 0;
        #endregion
    }
}
