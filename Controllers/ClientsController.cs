using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
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
        public IEnumerable<ClientDTO> GetClients()
        {
            var clients = _repository.GetClients().Select(client => client.AsDTO());
            return clients;
        }
        
        // GET /client/{id}
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetClient( Guid id )
        {
            var client = _repository.GetClient(id);

            if (client is null)
            {
                return NotFound();
            }

            return Ok(client.AsDTO());
        } 
    }
}
