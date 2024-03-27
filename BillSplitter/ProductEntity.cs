namespace BillSplitter
{
    public class ProductEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public ProductEntity(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }

    }
}
