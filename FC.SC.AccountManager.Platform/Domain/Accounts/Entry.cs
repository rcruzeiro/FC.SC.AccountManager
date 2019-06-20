using System;

namespace FC.SC.AccountManager.Platform.Domain.Accounts
{
    public class Entry : IValueObject
    {
        public int Id { get; protected set; }

        public int AccountId { get; set; }

        public int RelatedAccountId { get; set; }

        public OperationType OperationType { get; protected set; }

        public decimal Value { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        protected Entry()
        { }

        public Entry(Account account, Account relatedAccount, OperationType operationType, decimal value)
        {
            AccountId = account.Id;
            RelatedAccountId = relatedAccount.Id;
            OperationType = operationType;
            Value = value;
            CreatedAt = DateTimeOffset.Now;
        }
    }
}
