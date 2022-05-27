using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InmuebleFeatures.Commands
{
    public class CreateInmuebleCommand : IRequest<Inmueble>
    {
        public string agencyId { get; set; }
        public decimal price { get; set; }
        public Location location { get; set; }
        public string operationType { get; set; }
        public string type { get; set; }
        public int rooms { get; set; }
        public int baths { get; set; }
        public class CreateInmuebleCommandHandler : IRequestHandler<CreateInmuebleCommand, Inmueble>
        {
            private readonly IApplicationDbContext _context;
            public CreateInmuebleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Inmueble> Handle(CreateInmuebleCommand command, CancellationToken cancellationToken)
            {
                var inmueble = new Inmueble();
                inmueble.agencyId = command.agencyId;
                inmueble.price = command.price;
                inmueble.operationType = command.operationType;
                inmueble.type = command.type;
                inmueble.rooms = command.rooms;
                inmueble.baths = command.baths;
                inmueble.location = command.location;
                _context.Inmuebles.Add(inmueble);
                await _context.SaveChangesAsync();
                return inmueble;
            }
        }
    }
}
