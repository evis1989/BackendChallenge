using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.InmuebleFeatures.DTOs
{
    public class CreateInmuebleDto 
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