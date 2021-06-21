using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
namespace MatchmakerBotAPI.Core.Models.MatchmakerUsers
{
    public class MatchmakerUsersModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public MatchmakerScoreModel[] servers { get; set; }
    }
}