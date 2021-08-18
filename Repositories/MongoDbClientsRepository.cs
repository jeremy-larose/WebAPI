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

        public async Task<Client> GetClientAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(client => client.Id, id);
            return await _clientsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientsCollection.Find( new BsonDocument()).ToListAsync();
        }

        public async Task CreateClientAsync(Client client)
        {
            await _clientsCollection.InsertOneAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            var filter = _filterBuilder.Eq(existingClient => existingClient.Id, client.Id);
            await _clientsCollection.ReplaceOneAsync(filter, client);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(existingClient => existingClient.Id, id);
            await _clientsCollection.DeleteOneAsync( filter );
        }
    }
}
