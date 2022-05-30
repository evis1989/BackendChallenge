using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.PropertiesFeatures.Queries
{
    public class GetAllPropertiesByIdAgencyQuery : IRequest<IEnumerable<Property>>
    {
        [Required]
        public Guid agencyId { get; set; }
    }
}
