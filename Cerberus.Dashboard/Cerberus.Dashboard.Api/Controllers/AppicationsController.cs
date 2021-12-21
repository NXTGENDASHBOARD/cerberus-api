using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.DeleteApplication;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.CreateApplication;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetAllApplications;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationById;


using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.UpdateApplication;

namespace Cerberus.Dashboard.Api.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class AppicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AppicationsController> _logger;
        public AppicationsController(IMediator mediator, ILogger<AppicationsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// Gets all applications in the data storage
        /// </summary>
        /// <returns>List of applications</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllApplicationsQuery()));
        }

        /// <summary>
        /// Get Application in data storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns model="Application">Application</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetApplicationByIdQuery { Id = id }));
        }

        /// <summary>
        /// Creates a new Application record
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Application Id</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateApplicationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Removes an Application record
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delted Application Id</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _mediator.Send(new DeleteApplicationByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates an Application record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns>Updated Application Id</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateApplicationCommand command)
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
