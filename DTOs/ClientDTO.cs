using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public record ClientDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public DateTimeOffset LastVisitDate { get; init; }
    }
}
