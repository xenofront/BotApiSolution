using BotApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotApi.DB
{
    public class ReservationRepository : BaseRepository<IReservationModel, ReservationModel>
    {
        public ReservationRepository() : base(DBCollections.Reservation) { }

        public virtual async Task<IReservationModel> FindOneAsync(ObjectId objectId)
        {
            return await Collection.AsQueryable().Where(x => x.User == objectId).FirstOrDefaultAsync();
        }

        public virtual async Task UpsertOneAsync(IReservationModel record, ObjectId objectId)
        {
            var user = await Collection.AsQueryable().Where(x => x.User == objectId).FirstOrDefaultAsync();

            if (user is null)
                await InsertRecordAsync(Collection, record);
            else
            {
                record.UpdatedAt = DateTime.Now;
                List<UpdateDefinition<IReservationModel>> chain = new();

                foreach (var x in record.GetType().GetProperties())
                {
                    if (x.Name != "Id")
                    {
                        var value = x.GetValue(record);
                        if (value is not null)
                            chain.Add(Builders<IReservationModel>.Update.Set(x.Name, value));
                    }
                }

                await Collection.UpdateOneAsync(x => x.User == objectId, Builders<IReservationModel>.Update.Combine(chain));
            }
        }

        public virtual async Task<IReservationModel> GetOneAsync(ObjectId objectId)
        {
            return await Collection.AsQueryable().Where(x => x.User == objectId).FirstOrDefaultAsync();
        }
    }
}
