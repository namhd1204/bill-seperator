using BillSplitter;
using System.Net.WebSockets;
using System.Reflection.Metadata;

namespace App.BillSplitter
{
    public class BillPerson
    {
        public string PersonName { get; set; }
        public decimal PayAmount { get; set; }
        public decimal CurrentAmount
        {
            get
            {
                return BillItems.Sum(item => item.GetPrice());
            }
        }
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
            Console.WriteLine($"Tong cong = {CurrentAmount}");
            Console.WriteLine("************************\n\n");
        }

        internal bool HasEnoughToPay()
        {
            return PayAmount == CurrentAmount;
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
            return PayAmount < CurrentAmount + product.Price;
        }

        public bool NotExceedAmountButCannotFull(ProductEntity product, decimal minPriceOfProduct)
        {
            decimal currentAddNew = CurrentAmount + product.Price;
            decimal remain = PayAmount - currentAddNew;
            return remain > 0 && remain < minPriceOfProduct || ExceedAmount(product);
        }
    }
}
