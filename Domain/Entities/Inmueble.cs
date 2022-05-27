using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Inmueble : BaseEntity
    {
        public string agencyId { get; set; }
        public decimal price { get; set; }
        public Location location { get; set; }
        public string operationType { get; set; }
        public string type { get; set; }
        public int rooms { get; set; }
        public int baths { get; set; }

    }
}
