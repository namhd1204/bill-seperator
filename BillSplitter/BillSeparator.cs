using BillSplitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BillSplitter
{
    public class BillSeparator
    {
        public Bill BillInput { get; set; }
        public List<BillPerson> Persons { get; set; }

        public BillSeparator(Bill bill, List<BillPerson> persons)
        {
            BillInput = bill;
            Persons = persons;
        }

        public void Separate() 
        {
      
            var stackOfProduct = BillInput.CreateStackBillProduct();
            var minPriceOfProduct = stackOfProduct.Min(p => p.Price);
            var queueOfPerson = GetQueueOfPerson();
            var tempStack = new Stack<ProductEntity>(stackOfProduct.Count);
            while (stackOfProduct.Count > 0)
            {
                var product = stackOfProduct.Peek();
                var person = queueOfPerson.Peek();
                if (person.HasEnoughToPay())
                {
                    continue;
                }

                if (person.NotExceedAmountButCannotFull(product, minPriceOfProduct))
                {
                    tempStack.Push(stackOfProduct.Pop());
                    continue;
                }
                if (person.ExceedAmount(product))
                {
                    queueOfPerson.Enqueue(person);
                    continue;
                }
                person.Pay(product);

                stackOfProduct.Pop();
                queueOfPerson.Enqueue(queueOfPerson.Dequeue());
                if(tempStack.Count > 0)
                {
                    Move(tempStack, stackOfProduct);
                }
            }
        }

        private void Move(Stack<ProductEntity> tempStack, Stack<ProductEntity> stackOfProduct)
        {
            while(tempStack.Count > 0)
            {
                stackOfProduct.Push(tempStack.Pop());
            }
        }

        private Queue<BillPerson> GetQueueOfPerson()
        {
            return new Queue<BillPerson>(Persons);
        }
    }
}
