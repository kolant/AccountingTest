using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingTest.Common.Enum;
using AccountingTest.Service.Transactions;
using Microsoft.AspNetCore.Mvc;
using AccountingTest.Domain.Models;
using AccountingTest.Web.ViewModels;
using AutoMapper;

namespace AccountingTest.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/transactions")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService,
            IMapper mapper)
        {
            this._transactionService = transactionService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await this._transactionService.GetTransactionsAsync();

            var transactionViewModels =
                _mapper.Map<IEnumerable<Transaction>, IEnumerable< TransactionViewModel>>(transactions);

            return Json(transactionViewModels);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransaction(string transactionId)
        {
            var transaction = await this._transactionService.GetTransactionAsync(transactionId);

            if (transaction == null)
            {
                return NotFound();
            }

            var transactionViewModel = _mapper.Map<Transaction, TransactionViewModel>(transaction);

            return Json(transactionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CommitTransaction([FromBody] CommitTransactionRequest request)
        {
            await this._transactionService.CommitTransactionAsync(request.Type, request.Amount);

            return Ok();
        }

        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> DeleteTransaction(string transactionId)
        {
            await this._transactionService.DeleteTransactionAsync(transactionId);

            return Ok();
        }
    }
}