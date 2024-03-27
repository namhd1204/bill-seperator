using App.BillSplitter;
using BillSplitter;

var bill = new Bill();

bill.Init();

List<List<BillPerson>> testcase = new List<List<BillPerson>>()
{
    new List<BillPerson>()
    {
        new BillPerson("A", 12000),
        new BillPerson("B", 7000),
        new BillPerson("C", 1000),
    },
    //new List<BillPerson>()
    //{
    //    new BillPerson("A", 2000),
    //    new BillPerson("B", 17000),
    //    new BillPerson("C", 1000),
    //},
    //new List<BillPerson>()
    //{
    //    new BillPerson("A", 450),
    //    new BillPerson("B", 650),
    //    new BillPerson("C", 18900),
    //}
};


foreach (var billPersons in testcase)
{
    var billSeparator = new BillSeparator(bill, billPersons);

    try
    {
        billSeparator.Separate();
        foreach (var person in billPersons)
        {
            person.Print();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}




