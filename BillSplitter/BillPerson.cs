using BillSplitter;
using System.Net.WebSockets;
using System.Reflection.Metadata;

namespace App.BillSplitter
{
    public class BillPerson
    {
        public string PersonName { get; set; }
        public decimal PayAmount { get; set; }
        public List<BillItem> BillItems { get; set; }
        private List<ProductEntity> Products { get; set; }
        public BillPerson(string personName, decimal payAmount)
        {
            PersonName = personName;
            PayAmount = payAmount;

            BillItems = new List<BillItem>();
            Products = new List<ProductEntity>();
        }

        public void Print()
        {
            Console.WriteLine($"{PersonName} phai tra {PayAmount}");
            Console.WriteLine("------------------------");
            foreach (var item in BillItems)
            {
                item.Print();
            }
            Console.WriteLine("------------------------");
            Console.WriteLine($"Tong cong = {GetCurrentAmount()}");
            Console.WriteLine("************************\n\n");
        }

        internal bool HasEnoughToPay()
        {
            decimal currentAmount = GetCurrentAmount();
            return PayAmount == currentAmount;
        }

        private decimal GetCurrentAmount()
        {
            return BillItems.Sum(item => item.GetPrice());
        }

        public void Pay(ProductEntity product)
        {
            Products.Add(product);
            ProductsToBillItems();
        }

        private void ProductsToBillItems()
        {
            BillItems = Products
                .GroupBy(p => p)
                .Select(group =>
                {
                    return new BillItem(group.Key.ProductName, group.Key.Price, group.Count());
                })
                .ToList();
        }

        public bool ExceedAmount(ProductEntity product)
        {
            decimal currentAmount = GetCurrentAmount();
            return PayAmount < currentAmount + product.Price;
        }

        public bool NotExceedAmountButCannotFull(ProductEntity product, decimal minPriceOfProduct)
        {
            decimal currentAmount = GetCurrentAmount();
            decimal currentAddNew = currentAmount + product.Price;
            decimal remain = PayAmount - currentAddNew;
            return remain > 0 && remain < minPriceOfProduct || ExceedAmount(product);
        }
    }
}
