using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public record CreateClientDTO
    {
        [Required] public string Name { get; init; }
        [Required] public string Email { get; init; }
    }
}