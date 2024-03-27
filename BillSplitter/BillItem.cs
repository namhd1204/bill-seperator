namespace BillSplitter
{
    public class BillItem
    {
        public BillItem(string productName, decimal price, int quantity)
        {
            Product = new ProductEntity(productName, price);
            Quantity = quantity;
        }

        public ProductEntity Product { get; set; }
        public int Quantity { get; set; }
        public decimal GetPrice()
        {
            return Product.Price * Quantity;
        }

        internal void Print()
        {
            Console.WriteLine($"{Product.ProductName} => {Product.Price} x {Quantity} = {GetPrice()}");
        }
    }
}
