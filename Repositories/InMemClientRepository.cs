using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public class InMemClientRepository : IClientsRepository
    {
        private readonly List<Client> _clients = new()
        {
            new Client()
                { Id = Guid.NewGuid(), Name = "Doug LaRose", Price = 160, CreatedDate = DateTimeOffset.UtcNow },
            new Client() 
                { Id = Guid.NewGuid(), Name = "Kelly Blouw", Price = 80, CreatedDate = DateTimeOffset.UtcNow },
            new Client()
                { Id = Guid.NewGuid(), Name = "Jason Gagnon", Price = 240, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Client> GetClients()
        {
            return _clients;
        }

        public Client GetClient( Guid id )
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }
    }
}