using Application.DTOs.Locations;
using System;
using System.ComponentModel.DataAnnotations;


namespace Application.Features.PropertiesFeatures.DTOs
{
    public class CreatePropertiesDto 
    {
        [Required]
        public Guid agencyId { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public CreateLocationDto location { get; set; }
        [Required]
        public string operationType { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int rooms { get; set; }
        [Required]
        public int baths { get; set; }
    }
}