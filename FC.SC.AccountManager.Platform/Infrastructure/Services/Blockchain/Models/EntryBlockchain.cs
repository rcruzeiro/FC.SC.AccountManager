using MongoDB.Bson;

namespace FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain.Models
{
    public class EntryBlockchain : Blockchain
    {
        public ObjectId _id { get; set; }
    }
}
