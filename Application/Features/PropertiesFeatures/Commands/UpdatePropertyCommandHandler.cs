using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertiesFeatures.Commands
{
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertiesCommand, BaseCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        public UpdatePropertyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseCommandResponse> Handle(UpdatePropertiesCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var property = _context.Properties.FirstOrDefault(a => a.Id == command.PropertyDto.id);
            if (property == null) throw new NotFoundException();
            else
            {
                if (command.PropertyDto.agencyId != null)
                    property.AgencyId = command.PropertyDto.agencyId;
                if (command.PropertyDto.price != 0)
                    property.Price = command.PropertyDto.price;
                if (command.PropertyDto.operationType != null)
                    property.OperationType = command.PropertyDto.operationType;
                if (command.PropertyDto.type != null)
                    property.Type = command.PropertyDto.type;
                if (command.PropertyDto.rooms != 0)
                    property.Rooms = command.PropertyDto.rooms;
                if (command.PropertyDto.baths != 0)
                    property.Baths = command.PropertyDto.baths;

                await _context.SaveChangesAsync();
                response.Id = property.Id;
                response.Success = true;
                response.Message = "Property Updated!";
                return response;
            }
        }
    }
}
