using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Application.Accounts.Commands;
using FC.SC.AccountManager.Platform.Application.Accounts.DTO;
using FC.SC.AccountManager.Platform.Domain.Accounts;
using FC.SC.AccountManager.Platform.Domain.Accounts.Specifications;
using FC.SC.AccountManager.Platform.Domain.Blockchain;
using FC.SC.AccountManager.Platform.Domain.Blockchain.Services;

namespace FC.SC.AccountManager.Platform.Application.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        readonly IAccountRepository _accountRepository;
        readonly IEntryBlockchainService _entryBlockchainService;

        public AccountAppService(IAccountRepository accountRepository,
            IEntryBlockchainService entryBlockchainService)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _entryBlockchainService = entryBlockchainService ?? throw new ArgumentNullException(nameof(entryBlockchainService));
        }

        public async Task CreateAccount(CreateAccountCommand command, CancellationToken cancellationToken = default)
        {
            var account = Account.Create(command.Value);

            await _accountRepository.AddAsync(account, cancellationToken);
            await _accountRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task MakeTransfer(MakeTransferCommand command, CancellationToken cancellationToken = default)
        {
            // get both source and destiny accounts
            var account = await _accountRepository.GetOneAsync(new GetAccountSpecification(command.SourceAccountId), cancellationToken);

            if (account == null) throw new ArgumentNullException(nameof(account));

            var relatedAccount = await _accountRepository.GetOneAsync(new GetAccountSpecification(command.DestinyAccountId), cancellationToken);

            if (relatedAccount == null) throw new ArgumentNullException(nameof(relatedAccount));

            if (account.Id == relatedAccount.Id) throw new InvalidOperationException("it is not possible make transfer to same account.");

            // make the transfer between accounts
            var debitEntry = account.Transfer(relatedAccount, command.Value);

            // reflect as a deposit in related account
            var creditEntry = relatedAccount.Deposit(account, command.Value);

            // save updated accounts with theirs new entries
            _accountRepository.Update(new[] { account, relatedAccount });
            await _accountRepository.SaveChangesAsync();

            // save new entries to the blockchain
            await AddEntryToBlockchain(new[] { debitEntry, creditEntry });
        }

        public async Task<AccountDTO> GetAccount(GetAccountSpecification spec, CancellationToken cancellationToken = default)
        {
            var account = await _accountRepository.GetOneAsync(spec, cancellationToken);

            return account.ToDTO();
        }

        async Task AddEntryToBlockchain(IEnumerable<Entry> entries)
        {
            foreach (var entry in entries)
            {
                Block block = new Block(DateTimeOffset.Now, entry);
                await _entryBlockchainService.AddBlock(block);
            }
        }
    }
}
