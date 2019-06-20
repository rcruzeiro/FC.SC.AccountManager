using FC.SC.AccountManager.Platform.Domain.Accounts;
using FC.SC.AccountManager.Repository;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(IUnitOfWorkAsync unitOfWork)
            : base(unitOfWork)
        { }
    }
}
