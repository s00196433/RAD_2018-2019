using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.BankModels
{
    [Table("Customer")]
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
