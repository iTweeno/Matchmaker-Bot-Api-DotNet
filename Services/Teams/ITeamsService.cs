using MatchmakerBotAPI.Core.Models.Teams;
using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Models.PageModel;

namespace MatchmakerBotAPI.Core.Services.Teams
{
    public interface ITeamsService
    {
        Task<bool> AddTeam(TeamsModel team);

        Task<TeamsModel> GetTeamByPlayerId(string id, string guildId);

        Task<PageModel<TeamsModel>> GetTeamsByGuildId(string guildId, int page);
        
        Task<bool> EditTeam(string name, string guildId, TeamsModel team);

        Task<bool> DeleteTeam(string name, string guildId);
    }
}