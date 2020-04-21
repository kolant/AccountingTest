using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingTest.Common.Enum;

namespace AccountingTest.Web.ViewModels
{
    public class CommitTransactionRequest
    {
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
    }
}
