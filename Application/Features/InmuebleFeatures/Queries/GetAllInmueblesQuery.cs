using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InmuebleFeatures.Queries
{
    public class GetAllInmueblesQuery : IRequest<IEnumerable<Inmueble>>
    {

        public class GetAllInmueblesQueryHandler : IRequestHandler<GetAllInmueblesQuery, IEnumerable<Inmueble>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllInmueblesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Inmueble>> Handle(GetAllInmueblesQuery query, CancellationToken cancellationToken)
            {
                var inmueblesList = await _context.Inmuebles.ToListAsync();
                if (inmueblesList == null) return null;
                return inmueblesList.AsReadOnly();
            }
        }
    }
}
