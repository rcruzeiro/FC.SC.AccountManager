using FC.SC.AccountManager.Platform.Domain.Accounts;
using FC.SC.AccountManager.Repository;

namespace FC.SC.AccountManager.Platform.Application.Accounts.Specifications
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
