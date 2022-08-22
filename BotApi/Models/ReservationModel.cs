using BotApi.DB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;

namespace BotApi.Models
{
    [BsonSerializer(typeof(ImpliedImplementationInterfaceSerializer<IReservationModel, ReservationModel>))]
    public interface IReservationModel : IMongoEntity
    {
        DateTime? CreatedAt { get; set; }
        DateTime? DateFrom { get; set; }
        DateTime? DateUntil { get; set; }
        string Hotel { get; set; }
        string HotelCode { get; set; }
        int? Pax { get; set; }
        int? Rooms { get; set; }
        int? Adults { get; set; }
        int? Children { get; set; }
        int? Infants { get; set; }
        ObjectId User { get; set; }
        List<TouristModel> Turists { get; set; }
    }

    [BsonIgnoreExtraElements]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(ReservationModel))]
    public class ReservationModel : IReservationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreatedAt { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedAt { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DateFrom { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DateUntil { get; set; }
        public string Hotel { get; set; }
        public string HotelCode { get; set; }
        public int? Pax { get; set; }
        public int? Rooms { get; set; }
        public List<TouristModel> Turists { get; set; }
        public ObjectId User { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public int? Infants { get; set; }
    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(TouristModel))]
    public class TouristModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
    }
}