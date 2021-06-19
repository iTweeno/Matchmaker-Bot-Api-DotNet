using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;
using System.Threading.Tasks;
using System;
using MatchmakerBotAPI.Core.Connectors.MongoDB;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;
using MatchmakerBotAPI.Core.Models.PageModel;

namespace MatchmakerBotAPI.Core.Connectors.MatchmakerUsers
{
    public class MatchmakerUsersConnector : IMatchmakerUsersConnector
    {
        private IMongoCollection<MatchmakerUsersModel> _matchmakerUsersCollection;

        public MatchmakerUsersConnector(IMongoDBConnector mongoDBConnector)
        {
            _matchmakerUsersCollection = mongoDBConnector.GetCollection<MatchmakerUsersModel>("sixman");
        }
        public async Task<int> AddUser(MatchmakerUsersModel user)
        {
            var findUser = await _matchmakerUsersCollection.FindAsync(x => x.id == user.id);

            if (findUser.Any())
            {
                return 0;
            }

            try
            {
                await _matchmakerUsersCollection.InsertOneAsync(user);
                return 1;
            }
            catch (MongoBulkWriteException<MatchmakerUsersModel>)
            {
                return 0;
            }
        }

        public async Task<int> DeleteUser(string id)
        {
            var deleted = await _matchmakerUsersCollection.DeleteOneAsync(x => x.id == id);

            return Convert.ToInt32(deleted.DeletedCount);
        }

        public async Task<int> EditUser(string id, MatchmakerUsersModel user)
        {
            var update = Builders<MatchmakerUsersModel>.Update
            .Set(x => x.id, user.id)
            .Set(x => x.name, user.name)
            .Set(x => x.servers, user.servers);

            var edited = await _matchmakerUsersCollection.UpdateOneAsync<MatchmakerUsersModel>(x => x.id == id, update);

            return Convert.ToInt32(edited.ModifiedCount);
        }

        public async Task<MatchmakerUsersModel> GetUserById(string id)
        {
            var foundUser = await _matchmakerUsersCollection.FindAsync(x => x.id == id);

            return foundUser.FirstOrDefault();
        }

        public async Task<PageModel<MatchmakerUsersModel>> GetUsersByChannelId(string id, int page)
        {
            var filter = Builders<MatchmakerUsersModel>.Filter.ElemMatch(x => x.servers, Builders<MatchmakerScoreModel>.Filter.Where(x => x.channelId == id));

            var foundUsers = _matchmakerUsersCollection.Find(filter);

            var total = Convert.ToInt32(await foundUsers.CountDocumentsAsync());

            var items = await foundUsers.Skip(page * 20).Limit(20).ToListAsync();

            PageModel<MatchmakerUsersModel> pageReturn = new PageModel<MatchmakerUsersModel>(total, items);

            return pageReturn;
        }
    }
}