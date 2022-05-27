using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InmuebleFeatures.Commands
{
    public class DeleteInmuebleCommand : IRequest<Inmueble>
    {
        public int id { get; set; }
        public class DeleteInmuebleByIdCommandHandler : IRequestHandler<DeleteInmuebleCommand, Inmueble>
        {
            private readonly IApplicationDbContext _context;
            public DeleteInmuebleByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Inmueble> Handle(DeleteInmuebleCommand command, CancellationToken cancellationToken)
            {
                var inmueble = await _context.Inmuebles.Where(a => a.id == command.id).FirstOrDefaultAsync();
                if (inmueble == null) return null;
                _context.Inmuebles.Remove(inmueble);
                await _context.SaveChangesAsync();
                return inmueble;
            }
        }
    }
}
