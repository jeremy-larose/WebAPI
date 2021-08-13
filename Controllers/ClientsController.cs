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
                return NotFound();

            return Ok(client.AsDTO());
        }

        // POST /clients
        [HttpPost]
        public ActionResult<ClientDTO> CreateClient(CreateClientDTO clientDTO)
        {
            Client client = new()
            {
                Id = Guid.NewGuid(),
                Name = clientDTO.Name,
                Price = clientDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateClient( client );

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client.AsDTO());
        }

        // PUT /items/{id}
        [HttpPut( "{id}" )]
        public ActionResult UpdateClient(Guid id, UpdateClientDTO clientDTO)
        {
            var existingClient = _repository.GetClient(id);

            if (existingClient is null)
                return NotFound();

            Client updatedClient = existingClient with
            {
                Name = clientDTO.Name,
                Price = clientDTO.Price
            };

            _repository.UpdateClient( updatedClient );

            return NoContent();
        }

        [HttpDelete( "{id}")]
        public ActionResult Delete(Guid id)
        {
            var client = _repository.GetClient(id);

            if (client is null)
                return NotFound();

            _repository.DeleteClient(id);
            return NoContent();
        }
    }
}
