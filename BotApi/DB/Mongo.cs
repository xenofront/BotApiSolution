using BotApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace BotApi.DB
{
    public interface IMyDatabase<T>
    {
        IMongoCollection<T> Collection { get; }
    }

    public class Mongo<T> : IMyDatabase<T>
    {
        private readonly IMongoDatabase _db;
        public IMongoCollection<T> Collection { get; private set; }

        public Mongo(string database)
        {
            var client = new MongoClient();
            _db = client.GetDatabase("Test");
            Collection = _db.GetCollection<T>(database);

            RegisterMapIfNeeded<ReservationModel>();
            RegisterMapIfNeeded<BotUser>();
            RegisterMapIfNeeded<TouristModel>();
        }

        public void RegisterMapIfNeeded<C>()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(C)))
                BsonClassMap.RegisterClassMap<C>();
        }
    }
}