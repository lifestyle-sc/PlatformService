using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformService.Models
{
    public class Platform
    {
        [Column("PlatformId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of platform is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Publisher of platform is a requried field.")]
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "Cost of platform is a required field.")]
        public string? Cost { get; set; }  
    }
}
