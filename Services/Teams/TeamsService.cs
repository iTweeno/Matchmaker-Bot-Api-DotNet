using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Models.Teams;
using MatchmakerBotAPI.Core.Connectors.Teams;
using MatchmakerBotAPI.Core.Models.PageModel;

namespace MatchmakerBotAPI.Core.Services.Teams
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsConnector _teamsConnector;

        public TeamsService(ITeamsConnector teamsConnector)
        {
            _teamsConnector = teamsConnector;
        }
        public async Task<bool> AddTeam(TeamsModel team)
        {
            var inserted = await _teamsConnector.AddTeam(team);

            return inserted != 0;
        }

        public async Task<TeamsModel> GetTeamByPlayerId(string id, string guildId)
        {
            var team = await _teamsConnector.GetTeamByPlayerId(id, guildId);

            return team;
        }

        public async Task<PageModel<TeamsModel>> GetTeamsByGuildId(string guildId, int page)
        {
            var teams = await _teamsConnector.GetTeamsByGuildId(guildId, page);

            return teams;
        }

        public async Task<bool> EditTeam(string name, string guildId, TeamsModel team)
        {
            var edited = await _teamsConnector.EditTeam(name, guildId, team);

            return edited != 0;
        }

        public async Task<bool> DeleteTeam(string name, string guildId)
        {
            var deleted = await _teamsConnector.DeleteTeam(name, guildId);

            return deleted != 0;
        }
    }
}