using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public class MongoDbClientRepository : IClientsRepository
    {
        public MongoDbClientRepository( IMongoClient mongoClient )
        {
            
        }
        public Client GetClient(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
