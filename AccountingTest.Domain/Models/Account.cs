using System;
using System.Collections.Generic;
using System.Text;
using AccountingTest.Domain.Models;

namespace AccountingTest.Domain.Models
{
    public class Account : BaseEntity
    {
        public double BalanceValue { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
