using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingTest.Domain.Models;

namespace AccountingTest.Infrastructure.Abstractions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(string accountId);
    }
}