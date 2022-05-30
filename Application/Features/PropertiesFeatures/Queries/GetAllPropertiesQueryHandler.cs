using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertiesFeatures.Queries
{
    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesByIdAgencyQuery, IEnumerable<Property>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllPropertiesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Property>> Handle(GetAllPropertiesByIdAgencyQuery query, CancellationToken cancellationToken)
        {
            var propertiesList = await _context.Properties.Where(m => m.AgencyId == query.agencyId).ToListAsync();
            if (propertiesList == null) return null;
            return propertiesList.AsReadOnly();
        }
    }
}
