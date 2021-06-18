using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;
using System.Threading.Tasks;
namespace MatchmakerBotAPI.Core.Services.MatchmakerUsers
{
    public interface IMatchmakerUsersService
    {
       
      Task<MatchmakerUsersModel> GetUserById(string id);

      Task<bool> DeleteUser(string id);

      Task<bool> AddUser(MatchmakerUsersModel user);

      Task<bool> EditUser(string id, MatchmakerUsersModel user);
    }
}