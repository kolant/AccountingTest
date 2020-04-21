using System.Threading.Tasks;
using AccountingTest.Service.Account;
using Microsoft.AspNetCore.Mvc;

namespace AccountingTest.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            var account = await _accountService.GetDefaultAccountAsync();

            return Json(account);
        }
    }
}