using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingTest.Common.Enum;
using AccountingTest.Domain.Models;

namespace AccountingTest.Service.Transactions
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();

        Task<Transaction> GetTransactionAsync(string transactionId);

        Task CommitTransactionAsync(TransactionType type, double amount);

        Task DeleteTransactionAsync(string transactionId);
    }
}