using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI
{
    public static class Extensions
    {
        public static ClientDTO AsDTO(this Client client)
        {
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Price = client.Price,
                CreatedDate = client.CreatedDate,
            };
        }
    }
}
