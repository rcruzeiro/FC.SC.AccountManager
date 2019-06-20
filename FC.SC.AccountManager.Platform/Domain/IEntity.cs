using System;

namespace FC.SC.AccountManager.Platform.Domain
{
    public interface IEntity
    {
        int Id { get; }
        DateTimeOffset CreatedAt { get; }
        DateTimeOffset? UpdatedAt { get; }
    }
}
