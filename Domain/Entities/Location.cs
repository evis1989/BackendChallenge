using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Location : BaseEntity
    {
        public string city { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
    }
}
