
using MongoDB.Driver;

namespace MatchmakerBotAPI.Core.Connectors.MongoDB
{
    public interface IMongoDBConnector
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);

        IMongoDatabase GetMatchmakerDatabase();
    }
}