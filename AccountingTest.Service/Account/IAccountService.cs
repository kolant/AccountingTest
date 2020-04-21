using System.Threading.Tasks;
using AccountingTest.Common.Enum;

namespace AccountingTest.Service.Account
{
    public interface IAccountService
    {
        Task<AccountingTest.Domain.Models.Account> GetDefaultAccountAsync();

        Task<string> GetDefaultAccountIdAsync();

        Task UpdateDefaultAccountBalanceValue(TransactionType type, double amount);
    }
}