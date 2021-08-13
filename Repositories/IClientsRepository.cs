using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public interface IClientsRepository
    {
        Client GetClient(Guid id);
        IEnumerable<Client> GetClients();

        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Guid id );
    }
}
