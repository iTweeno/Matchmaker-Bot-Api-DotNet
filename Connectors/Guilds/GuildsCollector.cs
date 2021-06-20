using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Connectors.MongoDB;
using MatchmakerBotAPI.Core.Models.Guilds;
using MongoDB.Driver;
using System;

namespace MatchmakerBotAPI.Core.Connectors.Guilds
{
    public class GuildsCollector : IGuildsConnector
    {
        private readonly IMongoCollection<GuildsModel> _guildsCollection;

        public GuildsCollector(IMongoDBConnector mongoDBConnector)
        {
            _guildsCollection = mongoDBConnector.GetCollection<GuildsModel>("guilds");
        }
        public async Task<int> AddGuild(GuildsModel guild)
        {
            var findGuild = await _guildsCollection.FindAsync(x => x.id == guild.id);

            if (findGuild.Any())
            {
                return 0;
            }

            try
            {
                await _guildsCollection.InsertOneAsync(guild);
                return 1;
            }
            catch (MongoBulkWriteException<GuildsModel>)
            {
                return 0;
            }
        }

        public async Task<GuildsModel> GetGuildById(string id)
        {
            var foundGuild = await _guildsCollection.FindAsync(x => x.id == id);

            return foundGuild.FirstOrDefault();
        }

        public async Task<int> EditGuild(string id, GuildsModel guild)
        {
            var update = Builders<GuildsModel>.Update
            .Set(x => x.id, guild.id)
            .Set(x => x.channels, guild.channels);

            var edited = await _guildsCollection.UpdateOneAsync<GuildsModel>(x => x.id == id, update);

            return Convert.ToInt32(edited.ModifiedCount);
        }

        public async Task<int> DeleteGuild(string id)
        {
            var deleted = await _guildsCollection.DeleteOneAsync(x => x.id == id);

            return Convert.ToInt32(deleted.DeletedCount);
        }
    }
}