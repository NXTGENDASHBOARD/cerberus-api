using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.DeleteApplication;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.CreateApplication;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetAllApplications;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationById;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationsByInstitutionId;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantAPSDistribution;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantCourseTypeAll;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantFeederSchoolsAll;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantGenderAll;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantLocationAll;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantRaceAll;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationPipeline;
using Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationsCompleted;


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
        /// <summary>
        /// Returns Applications for a given Institution
        /// </summary> 
        /// <param name="id"></param>
        /// <returns model="Application">Application</returns> 
        [HttpGet("GetByInstitutionId/{InstitutionId}")]
        public async Task<IActionResult> GetByInstitutionIdAsync(int InstitutionId)
        {
            return Ok(await _mediator.Send(new GetApplicationsByInstitutionIdQuery { InstitutionId = InstitutionId }));
        }

        /// <summary>
        /// Returns Applications APS for a given Institution
        /// </summary> 
        /// 
        /// <returns model="DistributionApplicationAnalytic">DistributionApplicationAnalytic</returns> 
        [HttpGet("GetApplicantAPSDistribution")]
        public async Task<IActionResult> GetAllAPSDistributionAsync()
        {
            return Ok(await _mediator.Send(new GetApplicantAPSDistributionQuery()));
        }
        /// <summary>
        /// Returns Courses for all Applications
        /// </summary> 
        /// 
        /// <returns model="CourseTypeApplicationAnalytic">CourseTypeApplicationAnalytic</returns> 
        [HttpGet("GetApplicantCourseTypeAll")]
        public async Task<IActionResult> GetApplicantCourseTypeAllAsync()
        {
            return Ok(await _mediator.Send(new GetApplicantCourseTypeAllQuery()));
        }
        /// <summary>
        /// Returns Top Feeder Schools
        /// </summary> 
        /// 
        /// <returns model="FeederSchoolApplicationAnalytic">FeederSchoolApplicationAnalytic</returns> 
        [HttpGet("GetApplicantFeederSchoolsAll")]
        public async Task<IActionResult> GetApplicantFeederSchoolsAllAsync()
        {
            return Ok(await _mediator.Send(new GetApplicantFeederSchoolsAllQuery()));
        }
        /// <summary>
        /// Returns All Genders of Applicants
        /// </summary> 
        /// 
        /// <returns model="GenderApplicationAnalytic">GenderApplicationAnalytic</returns> 
        [HttpGet("GetApplicantGenderAll")]
        public async Task<IActionResult> GetApplicantGenderAllAsync()
        {
            return Ok(await _mediator.Send(new GetApplicantGenderAllQuery()));
        }
        /// <summary>
        /// Returns Locations of the applicants
        /// </summary> 
        /// 
        /// <returns model="LocationApplicationAnalytic">LocationApplicationAnalytic</returns> 
        [HttpGet("GetApplicantLocationAll")]
        public async Task<IActionResult> GetApplicantLocationAllAsync()
        {
            return Ok(await _mediator.Send(new GetApplicantLocationAllQuery()));
        }
        /// <summary>
        /// Returns Races of applicants
        /// </summary> 
        /// 
        /// <returns model="RaceApplicationAnalytic">RaceApplicationAnalytic</returns> 
        [HttpGet("GetApplicantRaceAll")]
        public async Task<IActionResult> GetApplicantRaceAllAsync()
        {
            return Ok(await _mediator.Send(new GetApplicantRaceAllQuery()));
        }
        /// <summary>
        /// Returns The counts in each stage the applications are in
        /// </summary> 
        /// 
        /// <returns model="PipelineApplicationAnalytic">PipelineApplicationAnalytic</returns> 
        [HttpGet("GetApplicationPipeline")]
        public async Task<IActionResult> GetApplicationPipelineAsync()
        {
            return Ok(await _mediator.Send(new GetApplicationPipelineQuery()));
        }
        /// <summary>
        /// Returns  The appplicants per period
        /// </summary> 
        /// 
        /// <returns model="CompletedApplicationAnalytic">CompletedApplicationAnalytic</returns> 
        [HttpGet("GetApplicationsCompleted")]
        public async Task<IActionResult> GetApplicationsCompletedQueryAsync()
        {
            return Ok(await _mediator.Send(new GetApplicationsCompletedQuery()));
        }
    }
}
