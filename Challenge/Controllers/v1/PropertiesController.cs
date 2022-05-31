using System;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.PropertiesFeatures.Commands;
using Application.Features.PropertiesFeatures.DTOs;
using Application.Features.PropertiesFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using log4net;

namespace Challenge.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PropertiesController : BaseApiController
    {
        readonly ILog logger = LogManager.GetLogger("debug");
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
            catch (Exception ex)
            {
                logger.Error(ex.Message,ex);
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
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Updates the Property based on Model.   
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePropertiesDto model)
        {
            try
            {
                var command = new UpdatePropertiesCommand { PropertyDto = model };
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                logger.Error(ex.Message, ex);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
