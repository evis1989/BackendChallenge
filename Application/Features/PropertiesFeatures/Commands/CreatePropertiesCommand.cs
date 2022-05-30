using Application.Features.PropertiesFeatures.DTOs;
using Application.Responses;
using MediatR;

namespace Application.Features.PropertiesFeatures.Commands
{
    public class CreatePropertiesCommand : IRequest<BaseCommandResponse>
    {
        public CreatePropertiesDto PropertyDto { get; set; }
    }
}
