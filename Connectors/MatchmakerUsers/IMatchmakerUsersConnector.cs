using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatchmakerBotAPI.Core.Models.PageModel;
namespace MatchmakerBotAPI.Core.Connectors.MatchmakerUsers
{
    public interface IMatchmakerUsersConnector
    {
        Task<MatchmakerUsersModel> GetUserById(string id);

        Task<PageModel<MatchmakerUsersModel>> GetUsersByChannelId(string id, int page);

        Task<int> DeleteUser(string id);

        Task<int> AddUser(MatchmakerUsersModel user);

        Task<int> EditUser(string id, MatchmakerUsersModel user);
    }
}