using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public interface IClientsRepository
    {
        Task<Client> GetClientAsync(Guid id);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id );
    }
}
