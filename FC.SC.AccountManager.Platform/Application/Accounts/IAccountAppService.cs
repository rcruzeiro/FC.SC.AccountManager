using System.Threading;
using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Application.Accounts.Commands;
using FC.SC.AccountManager.Platform.Application.Accounts.DTO;
using FC.SC.AccountManager.Platform.Domain.Accounts.Specifications;

namespace FC.SC.AccountManager.Platform.Application.Accounts
{
    public interface IAccountAppService
    {
        Task CreateAccount(CreateAccountCommand command, CancellationToken cancellationToken = default);
        Task MakeTransfer(MakeTransferCommand command, CancellationToken cancellationToken = default);
        Task<AccountDTO> GetAccount(GetAccountSpecification spec, CancellationToken cancellationToken = default);
    }
}
