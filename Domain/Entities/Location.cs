using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Location : ValueObject
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }

        public Location(string city,string zipcode,string address){
            City=city;
            ZipCode=zipcode;
            Address=address;
        }

         protected override IEnumerable<object> GetEqualityComponents(){
            yield return City;
            yield return ZipCode;
            yield return Address;
         }
    }

    
}
