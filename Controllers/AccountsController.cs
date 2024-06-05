using Code_First.Services;
using Microsoft.AspNetCore.Mvc;

namespace Code_First.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountId:int}")]
        public async Task<IActionResult> GetAccount(int accountId)
        {
            var account = await _accountService.GetAccountAsync(accountId);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
