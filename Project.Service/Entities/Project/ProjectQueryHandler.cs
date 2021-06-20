using System;
using System.Threading;
using System.Threading.Tasks;
using Project.Data.IRepositories;
using Project.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Project.Service.Subcribers
{
    public class ProjectQueryHandler : INotificationHandler<ProjectQueryEvent>
    {
        private readonly IProjectRepository _ProjectRepository;
        private readonly ILogger _logger;

        public ProjectQueryHandler(IProjectRepository ProjectRepository, ILogger<ProjectCreatedHandler> logger)
        {
            _ProjectRepository = ProjectRepository ?? throw new ArgumentNullException(nameof(ProjectRepository));
            _logger = logger;
        }

        public async Task Handle(ProjectQueryEvent notification, CancellationToken cancellationToken)
        {
            var Project = await _ProjectRepository.GetAsync(e => e.Id == notification.ProjectId);

            if (Project == null)
            {
                _logger.LogWarning("Project is not found by Project id from publisher");
            }
            else
            {
                _logger.LogInformation($"Project has found by Project id: {notification.ProjectId} from publisher");
            }
        }
    }
}