using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InmuebleFeatures.Queries
{
    public class GetInmuebleByIdQuery : IRequest<Inmueble>
    {
        public int id { get; set; }
        public class GetInmuebleByIdQueryHandler : IRequestHandler<GetInmuebleByIdQuery, Inmueble>
        {
            private readonly IApplicationDbContext _context;
            public GetInmuebleByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Inmueble> Handle(GetInmuebleByIdQuery query, CancellationToken cancellationToken)
            {
                var inmueble = _context.Inmuebles.Where(a => a.id == query.id).FirstOrDefault();
                if (inmueble == null) return null;
                return inmueble;
            }
        }
    }
}
