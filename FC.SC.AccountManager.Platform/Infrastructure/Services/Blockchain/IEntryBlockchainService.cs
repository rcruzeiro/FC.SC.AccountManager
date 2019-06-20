using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain.Models;

namespace FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain
{
    public interface IEntryBlockchainService
    {
        Task<EntryBlockchain> GetBlockchain();
        Task AddBlock(Block block);
    }
}
