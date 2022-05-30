using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Inmueble : BaseEntity
    {
        public string AgencyId { get; set; }
        public decimal Price { get; set; }
        public Location Location { get; set; }
        public string OperationType { get; set; }
        public string Type { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }

        public Inmueble(){
            
        }
    }
}
