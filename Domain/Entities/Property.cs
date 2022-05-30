using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Property : BaseEntity
    {
        public Guid AgencyId { get; set; }
        public decimal Price { get; set; }
        public Location Location { get; set; }
        public string OperationType { get; set; }
        public string Type { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }

        public Property(){}

        public Property(Guid agencyId, decimal price, Location location, string operationType, string type, int rooms, int baths)
        {
            AgencyId = agencyId;
            Price = price;
            Location = location;
            OperationType = operationType;
            Type = type;
            Rooms = rooms;
            Baths = baths;
        }
    }
}
