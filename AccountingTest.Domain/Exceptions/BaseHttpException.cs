using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AccountingTest.Domain.Exceptions
{
    public abstract class BaseHttpException : Exception
    {
        protected BaseHttpException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, Exception exception = null)
            : base(message, exception)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }
    }
}
