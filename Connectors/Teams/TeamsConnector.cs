using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Connectors.MongoDB;
using MatchmakerBotAPI.Core.Models.Teams;
using MongoDB.Driver;
using MatchmakerBotAPI.Core.Models.PageModel;
using System;

namespace MatchmakerBotAPI.Core.Connectors.Teams
{
    public class TeamsConnector : ITeamsConnector
    {
        private readonly IMongoCollection<TeamsModel> _teamsCollection;

        public TeamsConnector(IMongoDBConnector mongoDBConnector)
        {
            _teamsCollection = mongoDBConnector.GetCollection<TeamsModel>("teams");
        }
        public async Task<int> AddTeam(TeamsModel team)
        {
            var findTeam = await _teamsCollection.FindAsync(x => x.name == team.name && x.GuildId == team.GuildId);

            if (findTeam.Any())
            {
                return 0;
            }

            try
            {
                await _teamsCollection.InsertOneAsync(team);
                return 1;
            }
            catch (MongoBulkWriteException<TeamsModel>)
            {
                return 0;
            }
        }

        public async Task<TeamsModel> GetTeamByPlayerId(string id, string guildId)
        {
            var filter = Builders<TeamsModel>.Filter.And(
            Builders<TeamsModel>.Filter.Where(x=> x.GuildId == guildId),
            Builders<TeamsModel>.Filter.Or(
            Builders<TeamsModel>.Filter.AnyEq(x => x.players, id),
            Builders<TeamsModel>.Filter.Where(x => x.captain == id)));

            var foundTeam = await _teamsCollection.FindAsync(filter);

            return foundTeam.FirstOrDefault();
        }

        public async Task<PageModel<TeamsModel>> GetTeamsByGuildId(string guildId, int page)
        {
            var filter = Builders<TeamsModel>.Filter.Where(x => x.GuildId == guildId);

            var foundUsers = _teamsCollection.Find(filter);

            var total = Convert.ToInt32(await foundUsers.CountDocumentsAsync());

            var items = await foundUsers.Skip(page * 20).Limit(20).ToListAsync();

            PageModel<TeamsModel> pageReturn = new PageModel<TeamsModel>(total, items);

            return pageReturn;
        }

        public async Task<int> EditTeam(string name, string guildId, TeamsModel team)
        {
            var update = Builders<TeamsModel>.Update
            .Set(x => x.captain, team.captain)
            .Set(x => x.channels, team.channels)
            .Set(x => x.GuildId, team.GuildId)
            .Set(x => x.name, team.name)
            .Set(x => x.players, team.players);

            var edited = await _teamsCollection.UpdateOneAsync<TeamsModel>(x => x.name == name && x.GuildId == guildId, update);

            return Convert.ToInt32(edited.ModifiedCount);
        }

        public async Task<int> DeleteTeam(string name, string guildId)
        {
            var deleted = await _teamsCollection.DeleteOneAsync(x => x.name == name && x.GuildId == guildId);

            return Convert.ToInt32(deleted.DeletedCount);
        }
    }
}