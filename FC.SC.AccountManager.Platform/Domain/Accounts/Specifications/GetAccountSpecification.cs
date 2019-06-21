using FC.SC.AccountManager.Repository;

namespace FC.SC.AccountManager.Platform.Domain.Accounts.Specifications
{
    public sealed class GetAccountSpecification : BaseSpecification<Account>
    {
        public GetAccountSpecification(int id)
            : base(ac => ac.Id == id)
        {
            Includes.Add(ac => ac.Entries);
        }
    }
}
