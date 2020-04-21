using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AccountingTest.Domain.Exceptions
{
    public class NegativeBalanceException : BaseHttpException
    {
        public NegativeBalanceException()
            : base("The following transaction cannot be continued, it will lead to a negative balance.",
                HttpStatusCode.BadRequest)
        {
        }
    }
}
