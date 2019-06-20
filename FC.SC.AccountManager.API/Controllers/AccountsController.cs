using System;
using System.Threading;
using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Application.Accounts;
using FC.SC.AccountManager.Platform.Application.Accounts.Commands;
using FC.SC.AccountManager.Platform.Application.Accounts.DTO;
using FC.SC.AccountManager.Platform.Application.Accounts.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace FC.SC.AccountManager.API.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccountsController : Controller
    {
        readonly IAccountAppService _accountAppService;

        public AccountsController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService ?? throw new ArgumentNullException(nameof(accountAppService));
        }
        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="command">Create command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(Exception), 500)]
        public async Task<IActionResult> CreateAccount([FromBody]CreateAccountCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                await _accountAppService.CreateAccount(command, cancellationToken);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        /// <summary>
        /// Makes a transfer from the provided account to an destiny account.
        /// </summary>
        /// <param name="id">Source account identifier.</param>
        /// <param name="command">Transfer command.</param>
        /// <param name="cancellation">Cancellation token.</param>
        [HttpPost("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Exception), 500)]
        public async Task<IActionResult> MakeTransfer([FromRoute]int id, [FromBody]MakeTransferCommand command, CancellationToken cancellation = default)
        {
            try
            {
                command = new MakeTransferCommand(id, command.DestinyAccountId, command.Value);
                await _accountAppService.MakeTransfer(command, cancellation);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDTO), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        public async Task<IActionResult> GetAccount([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var spec = new GetAccountSpecification(id);

                var account = await _accountAppService.GetAccount(spec, cancellationToken);

                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
