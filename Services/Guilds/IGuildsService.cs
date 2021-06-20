using MatchmakerBotAPI.Core.Models.Guilds;
using System.Threading.Tasks;

namespace MatchmakerBotAPI.Core.Services.Guilds
{
    public interface IGuildsService
    {
        Task<bool> AddGuild(GuildsModel guild);

        Task<GuildsModel> GetGuildById(string id);
        
        Task<bool> EditGuild(string id, GuildsModel guild);

        Task<bool> DeleteGuild(string id);
    }
}