using System.Threading.Tasks;
using AccountingTest.Domain.Models;

namespace AccountingTest.Infrastructure.Abstractions
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
}