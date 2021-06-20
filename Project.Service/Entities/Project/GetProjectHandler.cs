using System;
using System.Threading;
using System.Threading.Tasks;
using Project.Data.IRepositories;
using Project.Domain.Dtos;
using Project.Domain.Queries;
using Project.Service.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Project.Service.Services
{
    public class GetProjectHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IProjectRepository _ProjectRepository;
        private readonly IProjectDxos _ProjectDxos;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public GetProjectHandler(IProjectRepository ProjectRepository, IProjectDxos ProjectDxos, IMediator mediator, ILogger<GetProjectHandler> logger)
        {
            _ProjectRepository = ProjectRepository ?? throw new ArgumentNullException(nameof(ProjectRepository));
            _ProjectDxos = ProjectDxos ?? throw new ArgumentNullException(nameof(ProjectDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var Project = await _ProjectRepository.GetAsync(e =>
                e.Id == request.ProjectId);

            if (Project != null)
            {
                await _mediator.Publish(new Domain.Events.ProjectQueryEvent(Project.Id), cancellationToken);
                _logger.LogInformation($"Got a request get Project Id: {Project.Id}");
                var ProjectDto = _ProjectDxos.MapProjectDto(Project);
                return ProjectDto;
            }

            return null;
        }
    }
}