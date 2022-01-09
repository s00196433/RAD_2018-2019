using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using ClassLibrary1.BankModels;

namespace consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Enter Customer ID to see transactions");
            int CustomerIDtransaction = Convert.ToInt32(Console.ReadLine());

            using (BankContext db = new BankContext())
            {
                //DateTime baseData = DateTime.Parse("09/01/2022");
                //Random r = new Random();

                //List<Customer> get_transactions = db.Customers.ToList();
                /* Console.WriteLine("get_transactions");
                 foreach (var item in get_transactions)
                 {
                         Console.WriteLine("{0}", item.Name);

                 }
             }
             Console.ReadLine(); */

                Console.WriteLine("get_transactions");
                var get_transactions = (from a in db.Accounts
                                           join t in db.Transactions
                                           on a.ID equals t.AccountID
                                           select new
                                           {
                                               CustomerID = a.CustomerID,
                                               TransactionID = t.ID,
                                               TransactionType = t.TransactionType,
                                               Amount = t.Amount,
                                               TransactionDate = t.TransactionDate
                                           })
                              .OrderBy(order => order.CustomerID);

                foreach (var item in get_transactions)
                {
                    if (item.CustomerID == CustomerIDtransaction)
                        Console.WriteLine("{0} ", String.Concat(item.CustomerID, " ", item.TransactionID, " ", item.TransactionType, " ", item.TransactionType, " " , item.Amount, " ", item.TransactionDate));
                }
            }
            Console.ReadLine();
        }
    }
}
