using System;

namespace FC.SC.AccountManager.Platform.Domain
{
    public interface IValueObject
    {
        int Id { get; }
        DateTimeOffset CreatedAt { get; }
    }
}
