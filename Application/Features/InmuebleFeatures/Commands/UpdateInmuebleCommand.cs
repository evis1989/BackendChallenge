using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InmuebleFeatures.Commands
{
    public class UpdateInmuebleCommand : IRequest<Inmueble>
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public class UpdateInmuebleCommandHandler : IRequestHandler<UpdateInmuebleCommand, Inmueble>
        {
            private readonly IApplicationDbContext _context;
            public UpdateInmuebleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Inmueble> Handle(UpdateInmuebleCommand command, CancellationToken cancellationToken)
            {
                var inmueble = _context.Inmuebles.Where(a => a.id == command.id).FirstOrDefault();
                if (inmueble == null) return null;
                else
                {
                    inmueble.price = command.price;
                    await _context.SaveChangesAsync();
                    return inmueble;
                }
            }
        }
    }
}
