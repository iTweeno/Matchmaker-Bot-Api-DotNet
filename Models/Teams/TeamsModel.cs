using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MatchmakerBotAPI.Core.Models.MatchmakerUsers;

namespace MatchmakerBotAPI.Core.Models.Teams
{
    public class TeamsModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string GuildId { get; set; }
        
        public string name { get; set; }

        public string captain { get; set; }

        public string[] players { get; set; }

        public MatchmakerScoreModel[] channels { get; set; }
    }
}