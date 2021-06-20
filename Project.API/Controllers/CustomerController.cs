using System;
using System.Threading.Tasks;
using Project.Domain.Commands;
using Project.Domain.Dtos;
using Project.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.API.Controllers
{

    public class ProjectController : ApiControllerBase

    {
        public ProjectController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get Project by id
        /// </summary>
        /// <param name="id">Id of Project</param>
        /// <returns>Project information</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProjectDto>> GetProjectAsync(Guid id)
        {
            return Single(await QueryAsync(new GetProjectQuery(id)));
        }

        /// <summary>
        /// Create new Project
        /// </summary>
        /// <param name="command">Info of Project</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateProjectAsync([FromBody] CreateProjectCommand command)
        {
            return Ok(await CommandAsync(command));
        }
    }
}