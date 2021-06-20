using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Models.Teams;
using MatchmakerBotAPI.Core.Models.PageModel;

namespace MatchmakerBotAPI.Core.Connectors.Teams
{
    public interface ITeamsConnector
    {
        
        Task<int> AddTeam(TeamsModel team);

        Task<TeamsModel> GetTeamByPlayerId(string id, string guildId);

        Task<PageModel<TeamsModel>> GetTeamsByGuildId(string guildId, int page);

        Task<int> EditTeam(string name, string guildId, TeamsModel team);

        Task<int> DeleteTeam(string name, string guildId);
    }
}