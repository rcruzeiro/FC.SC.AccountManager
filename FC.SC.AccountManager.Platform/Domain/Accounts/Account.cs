using System;
using System.Collections.Generic;

namespace FC.SC.AccountManager.Platform.Domain.Accounts
{
    public class Account : IEntity, IAggregationRoot
    {
        public int Id { get; protected set; }

        public decimal Balance { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset? UpdatedAt { get; protected set; }

        protected List<Entry> entries = new List<Entry>();
        public IReadOnlyCollection<Entry> Entries => entries;

        protected Account()
        { }

        public static Account Create(decimal balance)
        {
            return new Account
            {
                Balance = balance,
                CreatedAt = DateTimeOffset.Now
            };
        }

        public virtual Entry Transfer(Account relatedAccount, decimal value)
        {
            if (Id != default && relatedAccount.Id != default)
                if (Id == relatedAccount.Id) throw new InvalidOperationException("it is not possible make transfer to same account.");

            // validate account balance
            if (value > Balance) throw new InvalidOperationException("account does not have balance to make this transfer.");

            // create a new debit entry for this account
            var entry = new Entry(this, relatedAccount, OperationType.Debit, value);

            // make the debit
            Balance -= value;
            entries.Add(entry);
            UpdatedAt = DateTimeOffset.Now;

            return entry;
        }

        public virtual Entry Deposit(Account relatedAccount, decimal value)
        {
            if (Id != default && relatedAccount.Id != default)
                if (Id == relatedAccount.Id) throw new InvalidOperationException("it is not possible make deposit to same account.");

            // create a new credit entry for this account
            var entry = new Entry(this, relatedAccount, OperationType.Credit, value);

            // make the credit
            Balance += value;
            entries.Add(entry);
            UpdatedAt = DateTimeOffset.Now;

            return entry;
        }
    }
}
