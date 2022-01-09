namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClassLibrary1.BankModels;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibrary1.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassLibrary1.BankContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(customer => customer.ID, new Customer[] {
               new Customer
               {
                   ID = 1,
                   Name = "Customer 1",
                   Address ="Address for Customer 1"
               },
               new Customer
               {
                   ID = 2,
                   Name = "Customer 2",
                   Address ="Address for Customer 2"
               },
               new Customer
               {
                   ID = 3,
                   Name = "Customer 3",
                   Address ="Address for Customer 3"
               },
              
            });

            context.AccountTypes.AddOrUpdate(accountType => accountType.ID, new AccountType[] {
               new AccountType
               {
                   ID = 1,
                   TypeName = "Current",
                   Conditions = "Current Account Terms and conditions apply"
               },
               new AccountType
               {
                   ID = 2,
                   TypeName = "Savings",
                   Conditions = "Savings Account Terms and conditions apply"
               },
               new AccountType
               {
                   ID = 3,
                   TypeName = "Deposit",
                   Conditions = "Deposit Account Terms and conditions apply"
               },

              

            });
            context.Accounts.AddOrUpdate(account => account.ID, new Account[] {
               new Account
               {
                   ID=1,
                   AccountName="Current 1",
                   InceptionDate = DateTime.Parse("12/01/2002"),
                   CustomerID = 1,
                   CurrentBalance = 30000,
                   AccountTypeID=1
               },
               new Account
               {
                   ID=2,
                   AccountName="Current 2",
                   InceptionDate = DateTime.Parse("31/10/2004"),
                   CustomerID = 1,
                   CurrentBalance = 20000,
                   AccountTypeID=1
               },
               new Account
               {
                   ID=3,
                   AccountName=" Deposit 1",
                   InceptionDate = DateTime.Parse("10/10/2014"),
                   CustomerID = 2,
                   CurrentBalance = 10000,
                   AccountTypeID=3
               },
               new Account
               {
                   ID=4,
                   AccountName="Deposit 1",
                   InceptionDate = DateTime.Parse("03/05/2011"),
                   CustomerID = 3,
                   CurrentBalance =  50000,
                   AccountTypeID=3
               },
                new Account
               {
                   ID=5,
                   AccountName="Savings 1",
                   InceptionDate = DateTime.Parse("02/02/2010"),
                   CustomerID = 2,
                   CurrentBalance = 30000,
                   AccountTypeID=2
               },
              new Account
               {
                   ID=6,
                   AccountName="Current 1",
                   InceptionDate = DateTime.Parse("29/09/2004"),
                   CustomerID = 3,
                   CurrentBalance = 10000,
                   AccountTypeID=1
               },
            });
            context.Transactions.AddOrUpdate(transaction => transaction.ID, new Transactions[] {
               new Transactions
               {
                   ID=1,
                   TransactionType= (TransactionType)0,
                   Amount= 300,
                   TransactionDate= DateTime.Parse("18/01/2002"),
                   AccountID=1
               },
                new Transactions
               {
                   ID=2,
                   TransactionType= (TransactionType)1,
                   Amount= 500,
                   TransactionDate= DateTime.Parse("14/01/2002"),
                   AccountID=1
               },
                 new Transactions
               {
                   ID=3,
                   TransactionType= (TransactionType)1,
                   Amount= 300,
                   TransactionDate= DateTime.Parse("05/11/2004"),
                   AccountID=2
               },
                  new Transactions
               {
                   ID=4,
                   TransactionType= (TransactionType)0,
                   Amount= 200,
                   TransactionDate= DateTime.Parse("25/10/2014"),
                   AccountID=3
               },
               new Transactions
               {
                   ID=5,
                   TransactionType= (TransactionType)0,
                   Amount= 1000,
                   TransactionDate= DateTime.Parse("09/05/2011"),
                   AccountID=4
               },
              new Transactions
               {
                   ID=6,
                   TransactionType= (TransactionType)1,
                   Amount= 1000,
                   TransactionDate= DateTime.Parse("14/02/2010"),
                   AccountID=5
               },
              new Transactions
               {
                   ID=7,
                   TransactionType= (TransactionType)1,
                   Amount= 1000,
                   TransactionDate= DateTime.Parse("04/10/2004"),
                   AccountID=6
               },
            });


        }
    }
}
