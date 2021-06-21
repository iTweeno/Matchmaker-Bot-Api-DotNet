using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MatchmakerBotAPI.Core.Models.Guilds {
    public class GuildsModel {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        public string id {get; set;}

        public Dictionary<string, int> channels { get; set; }
    }
}