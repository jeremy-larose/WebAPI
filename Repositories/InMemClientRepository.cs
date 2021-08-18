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
                { Id = Guid.NewGuid(), Name = "Doug LaRose", Email = "dlarose@gmail.com", CreatedDate = DateTimeOffset.UtcNow },
            new Client() 
                { Id = Guid.NewGuid(), Name = "Kelly Blouw", Email = "kblouw@gmail.com", CreatedDate = DateTimeOffset.UtcNow },
            new Client()
                { Id = Guid.NewGuid(), Name = "Jason Gagnon", Email = "jgagnon@gmail.com", CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await Task.FromResult(_clients);
        }

        public async Task CreateClientAsync(Client client)
        {
            _clients.Add(client);
            await Task.CompletedTask;
        }

        public async Task UpdateClientAsync(Client client)
        {
            var index = _clients.FindIndex(existingClient => existingClient.Id == client.Id);
            _clients[index] = client;
            await Task.CompletedTask;
        }

        public async Task DeleteClientAsync(Guid id )
        {
            var index = _clients.FindIndex(existingClient => existingClient.Id == id);
            _clients.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<Client> GetClientAsync( Guid id )
        {
            var client = _clients.SingleOrDefault(client => client.Id == id);
            return await Task.FromResult(client);
        }
    }
}