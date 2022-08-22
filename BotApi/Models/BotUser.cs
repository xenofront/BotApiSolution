using BotApi.DB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace BotApi.Models
{
    [BsonSerializer(typeof(ImpliedImplementationInterfaceSerializer<IBotUser, BotUser>))]
    public interface IBotUser : IMongoEntity
    {
        long TelegramUserId { get; set; }
        string UserName { get; set; }
    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(BotUser))]
    public class BotUser : IBotUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedAt { get; set; }
        public long TelegramUserId { get; set; }
        public string UserName { get; set; }
    }
}
