using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClassLibrary1.BankModels
{
    [Table("Account")]
    public class Account
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string AccountName { get; set; }

        public DateTime InceptionDate { get; set; }

        [ForeignKey("customerAccounts")]
        public int CustomerID { get; set; }

        public decimal CurrentBalance { get; set; }

        public int AccountTypeID { get; set; }


        public virtual Customer customerAccounts { get; set; }




        /* public string ClubName { get; set; }
         [Column(TypeName = "date")]
         public DateTime CreationDate { get; set; }
         public int adminID { get; set; }
         public virtual ICollection<Member> clubMembers { get; set; }
         public virtual ICollection<ClubEvent> clubEvents { get; set; } */
    }
}
