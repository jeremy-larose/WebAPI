using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Repositories
{
    public interface IClientsRepository
    {
            IEnumerable<Client> GetClients();
            Client GetClient(Guid id);
    }
}
