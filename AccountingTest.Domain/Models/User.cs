using System;
using System.Collections.Generic;
using System.Text;
using AccountingTest.Domain.Models;

namespace AccountingTest.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
