using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotApi.DB
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
        DateTime? UpdatedAt { get; set; }
    }

    public interface IBaseServiceRepository<TCollection, TContext>
        where TCollection : IMongoEntity
        where TContext : IMongoEntity, new()
    {
        Task<IEnumerable<TCollection>> GetAllAsync(IMongoCollection<TCollection> collection);
        Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection, IEnumerable<long> telegramIds);
        Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection, IEnumerable<string> objIds);
        Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection, IEnumerable<TContext> contexts);
        Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, long telegramUserId);
        Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, string objId);
        Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, TContext context);
        Task InsertRecordAsync(IMongoCollection<TCollection> collection, TCollection record);
        Task UpsertAsync(IMongoCollection<TCollection> collection, TCollection record, long telegramUserId);
    }

    public abstract class BaseRepository<TCollection, TContext> : IBaseServiceRepository<TCollection, TContext> where TCollection : IMongoEntity
        where TContext : IMongoEntity, new()
    {
        public IMongoCollection<TCollection> Collection { get; set; }

        public BaseRepository(string collection)
        {
            Collection = new Mongo<TCollection>(collection).Collection;
        }

        public virtual async Task<IEnumerable<TCollection>> GetAllAsync(IMongoCollection<TCollection> collection)
        {

            return await collection.Find(f => true).ToListAsync();
        }

        public virtual async Task<IEnumerable<TCollection>> GetAllAsync()
        {
            return await Collection.Find(f => true).ToListAsync();
        }

        public virtual async Task InsertRecordAsync(TCollection record)
        {
            await Collection.InsertOneAsync(record);
        }

        public virtual async Task InsertRecordAsync(IMongoCollection<TCollection> collection, TCollection record)
        {
            await Collection.InsertOneAsync(record);
        }

        public virtual async Task UpsertAsync(IMongoCollection<TCollection> collection, TCollection record, long telegramUserId)
        {
            var filter = Builders<TCollection>.Filter.Eq("User.UserId", telegramUserId);
            var user = await collection.Find(filter).FirstOrDefaultAsync();

            if (user is null)
                await InsertRecordAsync(Collection, record);
            else
            {
                record.UpdatedAt = DateTime.Now;

                List<UpdateDefinition<TCollection>> chain = new();

                foreach (var x in record.GetType().GetProperties())
                {
                    if (x.Name != "Id")
                    {
                        var value = x.GetValue(record);
                        if (value is not null)
                            chain.Add(Builders<TCollection>.Update.Set(x.Name, value));
                    }
                }

                await Collection.UpdateOneAsync(x => x.Id == user.Id, Builders<TCollection>.Update.Combine(chain));
            }
        }

        public virtual async Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, TContext context)
        {
            return await collection.Find(x => x.Id == context.Id).FirstOrDefaultAsync();
        }

        public virtual async Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, long telegramUserId)
        {
            var filter = Builders<TCollection>.Filter.Eq("User.UserId", telegramUserId);

            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<TCollection> GetOneAsync(string objId)
        {
            ObjectId objectId = new(objId);

            return await Collection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }

        public virtual async Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, string objId)
        {
            ObjectId objectId = new(objId);

            return await collection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection, IEnumerable<TContext> contexts)
        {
            List<TCollection> list = new();

            foreach (var context in contexts)
            {
                var doc = await GetOneAsync(Collection, context);
                if (doc is null) continue;
                list.Add(doc);
            }

            return list;
        }

        public virtual async Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection, IEnumerable<string> objIds)
        {
            List<TCollection> list = new();

            foreach (var id in objIds)
            {
                var doc = await GetOneAsync(Collection, id);
                if (doc is null) continue;
                list.Add(doc);
            }

            return list;
        }

        public virtual async Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection, IEnumerable<long> telegramIds)
        {
            List<TCollection> list = new();

            foreach (var id in telegramIds)
            {
                var doc = await GetOneAsync(Collection, id);
                if (doc is null) continue;
                list.Add(doc);
            }

            return list;
        }

        public virtual async Task<IEnumerable<TCollection>> GetManyAsync(IEnumerable<long> telegramIds)
        {
            List<TCollection> list = new();

            foreach (var id in telegramIds)
            {
                var doc = await GetOneAsync(Collection, id);
                if (doc is null) continue;
                list.Add(doc);
            }

            return list;
        }
    }
}