using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public record PlatformForCreationDto
    {
        [Required(ErrorMessage = "Name of platform is a required field.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Publisher of platform is a requried field.")]
        public string? Publisher { get; init; }

        [Required(ErrorMessage = "Cost of platform is a required field.")]
        public string? Cost { get; init; }
    }
}
