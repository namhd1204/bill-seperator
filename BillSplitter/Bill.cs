using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitter
{
    public class Bill
    {
        public List<BillItem> Items { get; set; }

        public void Init()
        {
            Items = new List<BillItem>();

            Items.Add(new BillItem("Pho cuon", 100, 2));
            Items.Add(new BillItem("Mi xao", 100, 3));
            Items.Add(new BillItem("nem chua", 125, 4));
            Items.Add(new BillItem("lac", 100, 5));
            Items.Add(new BillItem("nom sua", 350, 2));
            Items.Add(new BillItem("tom rang", 200, 4));
            Items.Add(new BillItem("bun", 125, 8));
            Items.Add(new BillItem("Lau thai", 1000, 2));
            Items.Add(new BillItem("Nuong tokyo", 1000, 3));
            Items.Add(new BillItem("Tom hum con", 1000, 11));
        }

        public decimal GetPrice()
        {
            return Items.Sum(item => item.GetPrice());
        }

        public Stack<ProductEntity> CreateStackBillProduct()
        {
            List<ProductEntity> products = GetBillProduct();
            var stack = new Stack<ProductEntity>(products.OrderBy(p => p.Price).ToList());
            return stack;
        }

        private List<ProductEntity> GetBillProduct()
        {
            List<ProductEntity> products = new List<ProductEntity>();
            foreach (var item in Items)
            {
                for (int i = 1; i <= item.Quantity; i++)
                {
                    products.Add(item.Product);
                }
            }
            return products;
        }
    }
}
