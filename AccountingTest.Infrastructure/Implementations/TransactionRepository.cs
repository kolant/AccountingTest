using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingTest.Infrastructure.Abstractions;
using AccountingTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingTest.Infrastructure.Implementations
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(string accountId)
        {
            return await context.Transactions.Where(t => t.AccountId == accountId).ToListAsync();
        }
    }
}