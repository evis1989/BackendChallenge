using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PropertiesFeatures.Commands
{

    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertiesCommand, BaseCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        public CreatePropertyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BaseCommandResponse> Handle(CreatePropertiesCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var property = new Property();
            try
            {
                property.AgencyId = command.PropertyDto.agencyId;
                property.Price = command.PropertyDto.price;
                property.OperationType = command.PropertyDto.operationType;
                property.Type = command.PropertyDto.type;
                property.Rooms = command.PropertyDto.rooms;
                property.Baths = command.PropertyDto.baths;

                var location = new Location()
                {
                    City = command.PropertyDto.location.City,
                    ZipCode = command.PropertyDto.location.ZipCode,
                    Address = command.PropertyDto.location.Address
                };

                property.Location = location;
                _context.Properties.Add(property);
                await _context.SaveChangesAsync();
                response.Id = property.Id;
                response.Success = true;
                response.Message = "Property Created!";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Property Creation Failed";
                response.Errors = e.Message;
            }
            return response;
        }
    }
}
