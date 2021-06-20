using MatchmakerBotAPI.Core.Models.MatchmakerUsers;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatchmakerBotAPI.Core.Models.PageModel;
namespace MatchmakerBotAPI.Core.Connectors.MatchmakerUsers
{
    public interface IMatchmakerUsersConnector
    {
        Task<int> AddUser(MatchmakerUsersModel user);

        Task<MatchmakerUsersModel> GetUserById(string id);

        Task<PageModel<MatchmakerUsersModel>> GetUsersByChannelId(string id, int page);

        Task<int> EditUser(string id, MatchmakerUsersModel user);

        Task<int> DeleteUser(string id);
    }
}