using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route( "clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _repository;

        public ClientsController(IClientsRepository repository)
        {
            _repository = repository;
        }

        // GET /clients
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            var clients = _repository.GetClients();
            return clients;
        }
        
        // GET /client/{id}
        [HttpGet("{id}")]
        public ActionResult<Client> GetClient( Guid id )
        {
            var client = _repository.GetClient(id);

            if (client is null)
            {
                return NotFound();
            }

            return Ok(client);
        } 
    }
}
