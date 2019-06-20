using System;
using FC.SC.AccountManager.Platform.Domain.Accounts;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.Mongo.Repositories
{
    public class BaseRepository<T>
        where T : class
    {
        readonly string _collection;
        readonly IMongoDatabase _database;

        protected IMongoCollection<T> Collection
        { get { return _database.GetCollection<T>(_collection); } }

        protected BaseRepository(string connstring, string database, string collection)
        {
            _collection = collection;
            RegisterDiscriminators();
            MongoClient client = new MongoClient(connstring);
            _database = client.GetDatabase(database);
        }

        void RegisterDiscriminators()
        {
            try
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(Entry)))
                    BsonClassMap.RegisterClassMap<Entry>(bcm =>
                    {
                        bcm.AutoMap();
                        bcm.SetIdMember(bcm.GetMemberMap(c => c.Id));
                    });
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
