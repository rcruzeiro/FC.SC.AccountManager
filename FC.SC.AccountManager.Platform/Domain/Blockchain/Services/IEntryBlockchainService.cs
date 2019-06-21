using System.Threading.Tasks;

namespace FC.SC.AccountManager.Platform.Domain.Blockchain.Services
{
    public interface IEntryBlockchainService
    {
        Task<EntryBlockchain> GetBlockchain();
        Task AddBlock(Block block);
    }
}
