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
        public async Task<IEnumerable<ClientDTO>> GetClientsAsync()
        {
            var clients = (await _repository.GetClientsAsync())
                .Select(client => client.AsDTO());
            return clients;
        }
        
        // GET /client/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClientAsync( Guid id )
        {
            var client = await _repository.GetClientAsync(id);

            if (client is null)
                return NotFound();

            return Ok(client.AsDTO());
        }

        // POST /clients
        [HttpPost]
        public async Task<ActionResult<ClientDTO>> CreateClientAsync(CreateClientDTO clientDTO)
        {
            Client client = new()
            {
                Id = Guid.NewGuid(),
                Name = clientDTO.Name,
                Email = clientDTO.Email,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _repository.CreateClientAsync( client );

            return CreatedAtAction(nameof(GetClientAsync), new { id = client.Id }, client.AsDTO());
        }

        // PUT /items/{id}
        [HttpPut( "{id}" )]
        public async Task<ActionResult> UpdateClientAsync(Guid id, UpdateClientDTO clientDTO)
        {
            var existingClient = await _repository.GetClientAsync(id);

            if (existingClient is null)
                return NotFound();

            Client updatedClient = existingClient with
            {
                Name = clientDTO.Name,
                Email= clientDTO.Email
            };

            await _repository.UpdateClientAsync( updatedClient );

            return NoContent();
        }

        [HttpDelete( "{id}")]
        public async Task<ActionResult> DeleteClientAsync(Guid id)
        {
            var client = _repository.GetClientAsync(id);

            if (client is null)
                return NotFound();

            await _repository.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
