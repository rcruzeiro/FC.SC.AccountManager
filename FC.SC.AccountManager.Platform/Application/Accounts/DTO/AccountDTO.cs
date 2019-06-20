using System;
using System.Collections.Generic;
using System.Linq;
using FC.SC.AccountManager.Platform.Domain.Accounts;

namespace FC.SC.AccountManager.Platform.Application.Accounts.DTO
{
    public sealed class AccountDTO
    {
        public int Id { get; internal set; }
        public decimal Balance { get; internal set; }
        public DateTimeOffset CreatedAt { get; internal set; }
        public DateTimeOffset? UpdatedAt { get; internal set; }

        internal List<EntryDTO> entries = new List<EntryDTO>();
        public IReadOnlyCollection<EntryDTO> Entries => entries;
    }

    public static class AccountDTOExtensions
    {
        public static AccountDTO ToDTO(this Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            var dto = new AccountDTO
            {
                Id = account.Id,
                Balance = account.Balance,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            };

            // transform entry domain to DTO
            account.Entries
                .ToList().ForEach(ac => dto.entries.Add(ac.ToDTO()));

            return dto;
        }
    }
}
