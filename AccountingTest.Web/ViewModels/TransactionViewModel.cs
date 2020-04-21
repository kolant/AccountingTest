using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingTest.Common.Enum;

namespace AccountingTest.Web.ViewModels
{
    public class TransactionViewModel
    {
        public string Id;
        public double Amount;
        public DateTime EffectiveDate;
        public TransactionType Type;
    }
}
