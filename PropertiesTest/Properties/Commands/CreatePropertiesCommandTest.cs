using Application.DTOs.Locations;
using Application.Features.PropertiesFeatures.Commands;
using Application.Features.PropertiesFeatures.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PropertiesTest.Properties.Commands
{
    public class CreatePropertiesCommandTest
    {
        private readonly CreatePropertiesDto _propertiesDto;
        private readonly IApplicationDbContext _context;
        private readonly CreatePropertyCommandHandler _handler;

        public CreatePropertiesCommandTest()
        {
            _handler = new CreatePropertyCommandHandler(_context);

            var location = new CreateLocationDto
            {
                City = "Granollers",
                Address = "C/ Anselm Clave 61",
                ZipCode = "08420"
            };

            _propertiesDto = new CreatePropertiesDto
            {
                agencyId = Guid.Parse("4d4b1dd3-59c5-401f-a184-01e38340fdf4"),
                price = 1950000,
                location = location,
                operationType = "venta",
                type = "piso",
                rooms = 3,
                baths = 1
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new CreatePropertiesCommand() { PropertyDto = _propertiesDto }, CancellationToken.None);

            var properties = await _context.Properties.ToListAsync();

            result.ShouldBeOfType<BaseCommandResponse>();

            properties.Count.ShouldBe(1);
        }
    }
}
