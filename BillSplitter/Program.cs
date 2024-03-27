using App.BillSplitter;
using BillSplitter;

var bill = new Bill();

bill.Init();

var billPersons = new List<BillPerson>()
{
    new BillPerson("A", 20000),
    new BillPerson("B", 7000),
    new BillPerson("C", 1000),
};

var billSeparator = new BillSeparator(bill, billPersons);

billSeparator.Separate();


foreach (var person in billPersons)
{
    person.Print();
}