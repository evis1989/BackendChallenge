using Application.DTOs.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Properties
{
    public class GetPropertiesDto
    {
        public Guid Id { get; set; }
        public Guid AgencyId { get; set; }
        public decimal Price { get; set; }
        public CreateLocationDto Location { get; set; }
        public string OperationType { get; set; }
        public string Type { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
    }
}
