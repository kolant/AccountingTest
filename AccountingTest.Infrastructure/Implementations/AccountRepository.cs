using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingTest.Domain.Models;
using AccountingTest.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AccountingTest.Infrastructure.Implementations
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }
    }
}
