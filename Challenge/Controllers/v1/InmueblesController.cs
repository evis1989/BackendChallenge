using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.InmuebleFeatures.Commands;
using Application.Features.InmuebleFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InmueblesController : BaseApiController
    {
        /// <summary>
        /// Creates a New Inmueble.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateInmuebleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Inmuebles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllInmueblesQuery());
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Gets Inmueble by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetInmuebleByIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Deletes Inmueble based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteInmuebleCommand { Id = id });
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Updates the Inmueble based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateInmuebleCommand command)
        {
            var result = await Mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
