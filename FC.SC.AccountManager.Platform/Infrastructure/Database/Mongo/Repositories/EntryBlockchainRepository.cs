using System;
using System.Threading;
using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain.Models;
using MongoDB.Driver;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.Mongo.Repositories
{
    public class EntryBlockchainRepository : BaseRepository<EntryBlockchain>, IEntryBlockchainRepository
    {
        public EntryBlockchainRepository(string connstring, string database, string collection)
            : base(connstring, database, collection)
        { }

        public async Task<EntryBlockchain> GetBlockchain()
        {
            try
            {
                return await Collection.Find(_ => true)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task Create(EntryBlockchain blockchain, CancellationToken cancellationToken = default)
        {
            try
            {
                await Collection.InsertOneAsync(blockchain);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<bool> Update(EntryBlockchain blockchain, CancellationToken cancellationToken = default)
        {
            try
            {
                ReplaceOneResult updateResult =
                    await Collection.ReplaceOneAsync(
                        wbc => wbc._id == blockchain._id, blockchain);
                return updateResult.IsAcknowledged &&
                    updateResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
