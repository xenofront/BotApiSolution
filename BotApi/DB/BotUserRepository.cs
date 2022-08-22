using BotApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotApi.DB
{
    public class BotUserRepository : BaseRepository<IBotUser, BotUser>
    {
        public BotUserRepository() : base(DBCollections.User) { }

        public async Task<ObjectId> FindOrUpdateAsync(IBotUser record)
        {
            var user = await Collection.AsQueryable().Where(x => x.TelegramUserId == record.TelegramUserId).FirstOrDefaultAsync();

            if (user is not null)
            {
                return user.Id;
            }

            await base.InsertRecordAsync(record);

            return record.Id;
        }

        public async Task<ObjectId> GetUserId(long telegramUserId)
        {
            return await Collection.AsQueryable().Where(x => x.TelegramUserId == telegramUserId).Select(u => u.Id).FirstOrDefaultAsync();
        }
    }
}
