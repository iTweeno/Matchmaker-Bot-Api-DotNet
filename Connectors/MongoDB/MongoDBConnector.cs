
using MongoDB.Driver;

namespace MatchmakerBotAPI.Core.Connectors.MongoDB
{
    public class MongoDBConnector : IMongoDBConnector
    {
        public IMongoCollection<T> GetCollection<T>(string collectionName) {
            IMongoDatabase database = GetMatchmakerDatabase();

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);

            return collection;
        }
        public IMongoDatabase GetMatchmakerDatabase() {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("matchmaker");

            return database;
        }
    }
}