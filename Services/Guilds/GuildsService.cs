using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Models.Guilds;
using MatchmakerBotAPI.Core.Connectors.Guilds;

namespace MatchmakerBotAPI.Core.Services.Guilds
{
    public class GuildsService : IGuildsService
    {
        private readonly IGuildsConnector _guildsConnector;

        public GuildsService(IGuildsConnector guildsConnector)
        {
            _guildsConnector = guildsConnector;
        }
        public async Task<bool> AddGuild(GuildsModel guild)
        {
            var inserted = await _guildsConnector.AddGuild(guild);

            return inserted != 0;
        }

        public async Task<GuildsModel> GetGuildById(string id)
        {
            var guild = await _guildsConnector.GetGuildById(id);

            return guild;
        }

        public async Task<bool> EditGuild(string id, GuildsModel guild)
        {
            var edited = await _guildsConnector.EditGuild(id, guild);

            return edited != 0;
        }

        public async Task<bool> DeleteGuild(string id)
        {
            var deleted = await _guildsConnector.DeleteGuild(id);

            return deleted != 0;
        }
    }
}