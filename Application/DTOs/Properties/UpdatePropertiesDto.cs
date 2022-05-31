using System;
using System.ComponentModel.DataAnnotations;


namespace Application.Features.PropertiesFeatures.DTOs
{
    public class UpdatePropertiesDto
    {
        [Required]
        public Guid id { get; set; }
        public Guid agencyId { get; set; }
        public decimal price { get; set; }
        public string operationType { get; set; }
        public string type { get; set; }
        public int rooms { get; set; }
        public int baths { get; set; }
    }
}