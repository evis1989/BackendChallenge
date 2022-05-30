using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.PropertiesFeatures.Commands;
using Application.Features.PropertiesFeatures.DTOs;
using Application.Features.PropertiesFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PropertiesController : BaseApiController
    {
        /// <summary>
        /// Creates a New Property.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertiesDto model)
        {
            try
            {
                var command = new CreatePropertiesCommand { PropertyDto = model };
                return Ok(await Mediator.Send(command));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        /// <summary>
        /// Gets all Properties by IdAgency.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllByIdAgency([FromQuery] Guid agencyId)
        {
            try
            {
                var result = await Mediator.Send(new GetAllPropertiesByIdAgencyQuery { agencyId = agencyId });
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Updates the Property based on Model.   
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdatePropertiesDto model)
        {
            try
            {
                var command = new UpdatePropertiesCommand { PropertyDto = model };
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
