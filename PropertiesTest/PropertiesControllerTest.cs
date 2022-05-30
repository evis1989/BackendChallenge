using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;
using Challenge;
using System.Net;
using Application.Features.PropertiesFeatures.DTOs;
using Application.DTOs.Locations;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Application.Features.PropertiesFeatures.Queries;

namespace PropertiesTest
{
    public class PropertiesControllerTest
    {
        private readonly HttpClient _client;

        public PropertiesControllerTest()
        {
            var _appFactory = new WebApplicationFactory<Startup>();
            _client = _appFactory.CreateClient();
        }
        [Fact]
        public async Task CreateProperties()
        {
            var expectedResult = "{\"id\":1,\"success\":true,\"message\":\"Property Created!\",\"errors\":null}";
            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new CreatePropertiesDto();
            request.agencyId = Guid.Parse("4d4b1dd3-59c5-401f-a184-01e38340fdf4");
            request.price = 1950000;
            var location = new CreateLocationDto();
            location.City = "Granollers";
            location.Address = "C/ Anselm Clave 61";
            location.ZipCode = "08420";
            request.location = location;
            request.operationType = "venta";
            request.type = "piso";
            request.rooms = 3;
            request.baths = 1;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Properties", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async Task UpdateProperties()
        {
            var expectedResult = "{\"id\":1,\"success\":true,\"message\":\"Property Updated!\",\"errors\":null}";
            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new UpdatePropertiesDto();
            request.id = 1;
            request.price = 200000;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PatchAsync("/api/v1/Properties", content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async Task GetAllPropertiesByIdAgency()
        {
            var expectedResult = "";
            var expectedStatusCode = HttpStatusCode.NotFound;

            // Arrange
            var request = new GetAllPropertiesByIdAgencyQuery();
            request.agencyId = Guid.Parse("4d4b1dd3-59c5-401f-a184-01e38340fdf4");

            // Act
            var response = await _client.GetAsync("/api/v1/Properties/"+request.agencyId);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
