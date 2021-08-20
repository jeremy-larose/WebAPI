using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.Email
{
    public class UpdateEmailDTO
    {
        [Required] public string FromDisplayName { get; init; }
        [Required] public string ToDisplayName { get; init; }
        [Required] public string FromAddress { get; init; }
        [Required] public string ToAddress { get; init; }
        [Required] public string Subject { get; init; }
        [Required] public string Body { get; init; }
    }
}