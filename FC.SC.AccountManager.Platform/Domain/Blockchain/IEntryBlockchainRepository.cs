using System.Threading;
using System.Threading.Tasks;

namespace FC.SC.AccountManager.Platform.Domain.Blockchain
{
    public interface IEntryBlockchainRepository
    {
        Task<EntryBlockchain> GetBlockchain();
        Task Create(EntryBlockchain blockchain, CancellationToken cancellationToken = default);
        Task<bool> Update(EntryBlockchain blockchain, CancellationToken cancellationToken = default);
    }
}
