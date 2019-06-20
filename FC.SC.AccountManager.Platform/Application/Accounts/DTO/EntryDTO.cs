using System;
using FC.SC.AccountManager.Platform.Domain.Accounts;

namespace FC.SC.AccountManager.Platform.Application.Accounts.DTO
{
    public sealed class EntryDTO
    {
        public int Id { get; internal set; }
        public int RelatedAccountId { get; internal set; }
        public string OperationType { get; set; }
        public decimal Value { get; internal set; }
        public DateTimeOffset CreatedAt { get; internal set; }
    }

    public static class EntryDTOExtensions
    {
        public static EntryDTO ToDTO(this Entry entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));

            return new EntryDTO
            {
                Id = entry.Id,
                RelatedAccountId = entry.RelatedAccountId,
                OperationType = entry.OperationType.ToString(),
                Value = entry.Value,
                CreatedAt = entry.CreatedAt
            };
        }
    }
}
