using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public record CreateClientDTO
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string Email { get; init; }

    }
}
