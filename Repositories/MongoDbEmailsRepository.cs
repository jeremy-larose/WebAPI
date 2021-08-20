using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public class MongoDbEmailsRepository : IEmailsRepository
    {
        private const string DatabaseName = "catalog";
        private const string CollectionName = "emails";
        private readonly IMongoCollection<Email> _emailsCollection;
        private readonly FilterDefinitionBuilder<Email> _filterBuilder = Builders<Email>.Filter;

        public MongoDbEmailsRepository( IMongoClient mongoClient )
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _emailsCollection = database.GetCollection<Email>(CollectionName);
        }
        public async Task<Email> GetEmailAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(email => email.Id, id);
            return await _emailsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Email>> GetEmailsAsync()
        {
            return await _emailsCollection.Find( new BsonDocument()).ToListAsync();
        }

        public async Task CreateEmailAsync(Email email)
        {
            await _emailsCollection.InsertOneAsync(email);
        }

        public async Task UpdateEmailAsync(Email email)
        {
            var filter = _filterBuilder.Eq(existingEmail => existingEmail.Id, email.Id);
            await _emailsCollection.ReplaceOneAsync(filter, email);
        }

        public async Task DeleteEmailAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(existingEmail => existingEmail.Id, id);
            await _emailsCollection.DeleteOneAsync(filter);
        }
    }
}