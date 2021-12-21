
using Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.CreateInstitution;
using Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.DeleteInstitution;
using Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.UpdateInstitution;
using Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetAllInstitutions;
using Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetInstitutionById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Controllers
{
    [Route("api/institutions")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InstitutionsController> _logger;
        public InstitutionsController(IMediator mediator, ILogger<InstitutionsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Gets all institutions in the data storage
        /// </summary>
        /// <returns>List of institutions</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllInstitutionsQuery()));
        }

        /// <summary>
        /// Gets all applications in the data storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns model="Institution">Institution</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetInstitutionByIdQuery { Id = id }));
        }

        /// <summary>
        /// Creates a new Institution record
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Institution Id</returns
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateInstitutionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Removes an Institution record
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delted Institution Id</returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _mediator.Send(new DeleteInstitutionByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates an Institution record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns>Delted Command Id</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateInstitutionCommand command)
        {
            if (command == null)
            {
                _logger.LogError($"Invalid command parsed @: {DateTime.UtcNow.ToLocalTime()}");
                return BadRequest();
            }
            if (id != command.Id)
            {
                _logger.LogError($"Mismatch command parsed @: {DateTime.UtcNow.ToLocalTime()}");
                return BadRequest();
            }

            return Ok(await _mediator.Send(command));
        }
 
    }
}
