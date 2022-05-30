using Application.Features.PropertiesFeatures.DTOs;
using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.PropertiesFeatures.Commands
{
    public class UpdatePropertiesCommand : IRequest<BaseCommandResponse>
    {
        public UpdatePropertiesDto PropertyDto { get; set; }
        
    }
}
