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
using Application.Responses;
using Application.DTOs.Properties;
using System.Collections.Generic;

namespace PropertiesTest
{
    [TestCaseOrderer("PropertiesTest.PriorityOrderer", "PropertiesTest")]
    public class PropertiesControllerTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CreatePropertiesDto request;
        public PropertiesControllerTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();

            var location = new CreateLocationDto();
            location.City = "Granollers";
            location.Address = "C/ Anselm Clave 61";
            location.ZipCode = "08420";

            request = new CreatePropertiesDto();
            request.agencyId = Guid.Parse("4d4b1dd3-59c5-401f-a184-01e38340fdf4");
            request.price = 1950000;
            request.location = location;
            request.operationType = "venta";
            request.type = "piso";
            request.rooms = 3;
            request.baths = 1;
        }

        [Fact, TestPriority(1)]
        public async Task Create_Properties_Test()
        {
            var messageExpected = "Property Created!";
            var expectedStatusCode = HttpStatusCode.OK;

            var response = await CreateProperty();

            var actualStatusCode = response.StatusCode;
            var getResult = JsonConvert.DeserializeObject<BaseCommandResponse>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Null(getResult.Errors);
            Assert.True(getResult.Success);
            Assert.Equal(messageExpected, getResult.Message);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact, TestPriority(2)]
        public async Task Update_Properties_Test()
        {
            var response = await CreateProperty();
            var getResult = JsonConvert.DeserializeObject<BaseCommandResponse>(await response.Content.ReadAsStringAsync());

            var messageExpected = "Property Updated!";
            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var requestUpdate = new UpdatePropertiesDto();
            requestUpdate.id = getResult.Id;
            requestUpdate.price = 200000;

            var contentUpdate = new StringContent(JsonConvert.SerializeObject(requestUpdate), Encoding.UTF8, "application/json");

            // Act
            var responseUpdate = await _client.PatchAsync($"/v1/properties/{getResult.Id}", contentUpdate);

            var actualStatusCode = responseUpdate.StatusCode;
            var actualResultUpdate = await responseUpdate.Content.ReadAsStringAsync();
            var getResultUpdate = JsonConvert.DeserializeObject<BaseCommandResponse>(actualResultUpdate);

            // Assert
            Assert.Null(getResultUpdate.Errors);
            Assert.True(getResultUpdate.Success);
            Assert.Equal(messageExpected, getResultUpdate.Message);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact, TestPriority(3)]
        public async Task GetAll_Properties_ByIdAgency_Test()
        {
            var expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            var request = new GetAllPropertiesByIdAgencyQuery();
            request.agencyId = Guid.Parse("4d4b1dd3-59c5-401f-a184-01e38340fdf4");

            // Act
            var response = await _client.GetAsync("/v1/properties?agencyId=" + request.agencyId);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();
            var getResult = JsonConvert.DeserializeObject<List<GetPropertiesDto>>(actualResult);

            // Assert
            Assert.Single(getResult);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        public async Task<HttpResponseMessage> CreateProperty()
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            return await _client.PostAsync("/v1/properties", content);
        }
    }
}
