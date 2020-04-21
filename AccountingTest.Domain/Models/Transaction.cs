using System;
using AccountingTest.Common.Enum;

namespace AccountingTest.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; }

        public double Amount { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}