using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace MatchmakerBotAPI.Core.Services.MatchmakerUsers
{
    public interface IMatchmakerUsersService
    {

        Task<MatchmakerUsersModel> GetUserById(string id);

        Task<List<MatchmakerUsersModel>> GetUsersByChannelId(string id);

        Task<bool> DeleteUser(string id);

        Task<bool> AddUser(MatchmakerUsersModel user);

        Task<bool> EditUser(string id, MatchmakerUsersModel user);
    }
}