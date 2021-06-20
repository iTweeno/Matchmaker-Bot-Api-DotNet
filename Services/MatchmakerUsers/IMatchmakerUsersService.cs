using MatchmakerBotAPI.Core.Models.MatchmakerUsers;
using MatchmakerBotAPI.Core.Models.PageModel;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace MatchmakerBotAPI.Core.Services.MatchmakerUsers
{
    public interface IMatchmakerUsersService
    {
        Task<bool> AddUser(MatchmakerUsersModel user);

        Task<MatchmakerUsersModel> GetUserById(string id);

        Task<PageModel<MatchmakerUsersModel>> GetUsersByChannelId(string id, int page);
        
        Task<bool> EditUser(string id, MatchmakerUsersModel user);

        Task<bool> DeleteUser(string id);
    }
}