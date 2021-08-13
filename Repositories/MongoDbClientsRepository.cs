using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public class MongoDbClientsRepository : IClientsRepository
    {
        private const string DatabaseName = "catalog";
        private const string CollectionName = "clients";
        private readonly IMongoCollection<Client> _clientsCollection;
        private readonly FilterDefinitionBuilder<Client> _filterBuilder = Builders<Client>.Filter;

        public MongoDbClientsRepository( IMongoClient mongoClient )
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _clientsCollection = database.GetCollection<Client>(CollectionName);
        }

        public Client GetClient(Guid id)
        {
            var filter = _filterBuilder.Eq(client => client.Id, id);
            return _clientsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientsCollection.Find( new BsonDocument()).ToList();
        }

        public void CreateClient(Client client)
        {
            _clientsCollection.InsertOne(client);
        }

        public void UpdateClient(Client client)
        {
            var filter = _filterBuilder.Eq(existingClient => existingClient.Id, client.Id);
            _clientsCollection.ReplaceOne(filter, client);
        }

        public void DeleteClient(Guid id)
        {
            var filter = _filterBuilder.Eq(existingClient => existingClient.Id, id);
            _clientsCollection.DeleteOne( filter );
        }
    }
}
