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
        [Range(1, 1000)]
        public decimal Price { get; init; }
        [Required]
        [Range(1, 50)]
        public decimal HorseCount { get; init; }
        [Required]
        public string Location { get; init; }

    }
}
