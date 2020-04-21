using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingTest.Infrastructure.Abstractions;
using System.Data.Entity.Core;
using AccountingTest.Common.Enum;
using AccountingTest.Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountingTest.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<Domain.Models.Account> GetDefaultAccountAsync()
        {
            var account = (await this._accountRepository.GetAllAsync()).FirstOrDefault();

            if (account == null)
            {
                throw new ObjectNotFoundException();
            }

            return account;
        }

        public async Task<string> GetDefaultAccountIdAsync()
        {
            return (await this.GetDefaultAccountAsync()).Id;
        }

        public async Task UpdateDefaultAccountBalanceValue(TransactionType type, double amount)
        {
            var account = await GetDefaultAccountAsync();

            if (type == TransactionType.Credit)
            {
                if(account.BalanceValue - amount < 0)
                {
                    throw new NegativeBalanceException();
                }

                account.BalanceValue -= amount;
            }

            if (type == TransactionType.Debit)
            {
                account.BalanceValue += amount;
            }

            await _accountRepository.UpdateAsync(account);
        }
    }
}
