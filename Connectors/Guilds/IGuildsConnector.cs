using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Models.Guilds;
namespace MatchmakerBotAPI.Core.Connectors.Guilds
{
    public interface IGuildsConnector
    {
        
        Task<int> AddGuild(GuildsModel guild);

        Task<GuildsModel> GetGuildById(string id);

        Task<int> EditGuild(string id, GuildsModel guild);

        Task<int> DeleteGuild(string id);
    }
}