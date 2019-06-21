using MongoDB.Bson;

namespace FC.SC.AccountManager.Platform.Domain.Blockchain
{
    public class EntryBlockchain : Blockchain
    {
        public ObjectId _id { get; set; }
    }
}
