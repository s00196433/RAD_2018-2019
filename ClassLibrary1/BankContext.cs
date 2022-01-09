using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.BankModels;

namespace ClassLibrary1
{
    class BankContext : DbContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public BankContext()
            : base("BankConnection")
        {
        }
        public static BankContext Create()
        {
            return new BankContext();
        }
    }
}
