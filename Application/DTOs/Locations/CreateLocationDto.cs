using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Locations
{
    public class CreateLocationDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
