using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountingTest.Common.Enum;
using AccountingTest.Domain.Exceptions;
using AccountingTest.Domain.Models;
using AccountingTest.Infrastructure.Abstractions;
using AccountingTest.Service.Account;

namespace AccountingTest.Service.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepository transactionRepository,
            IAccountService accountService)
        {
            this._transactionRepository = transactionRepository;
            this._accountService = accountService;
        }

        public async Task CommitTransactionAsync(TransactionType type, double amount)
        {
            var account = await this._accountService.GetDefaultAccountAsync();
            await this._accountService.UpdateDefaultAccountBalanceValue(type, amount);
            var newTransacation = new Transaction()
            {
                Id = Guid.NewGuid().ToString(),
                Amount = amount,
                Type = type,
                EffectiveDate = DateTime.UtcNow,
                AccountId = account.Id
            };

            await this._transactionRepository.CreateAsync(newTransacation);
        }

        public async Task DeleteTransactionAsync(string transactionId)
        {
            var transaction = _transactionRepository.Get(transactionId);
            await _transactionRepository.DeleteAsync(transaction);
        }

        public async Task<Transaction> GetTransactionAsync(string transactionId)
        {
            return await _transactionRepository.GetAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }
    }
}
