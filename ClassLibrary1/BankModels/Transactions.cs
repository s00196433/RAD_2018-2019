using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.BankModels
{
    [Table("Transactions")]
    public class Transactions
    {
        public int ID { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        [ForeignKey("AccountTransaction")]
        public int AccountID { get; set; }


        public virtual Account AccountTransaction { get; set; }




    }

       
}
