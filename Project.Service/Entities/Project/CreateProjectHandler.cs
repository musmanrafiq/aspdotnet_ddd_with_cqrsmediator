using Project.Data.IRepositories;
using Project.Domain.Commands;
using Project.Domain.Common;
using Project.Domain.Dtos;
using Project.Service.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
    {
        private readonly IProjectRepository _ProjectRepository;
        private readonly IProjectDxos _ProjectDxos;
        private readonly IMediator _mediator;

        public CreateProjectHandler(IProjectRepository ProjectRepository, IMediator mediator, IProjectDxos ProjectDxos)
        {
            _ProjectRepository = ProjectRepository ?? throw new ArgumentNullException(nameof(ProjectRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _ProjectDxos = ProjectDxos ?? throw new ArgumentNullException(nameof(ProjectDxos));
        }


        public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (await _ProjectRepository.EmailExistAsync(request.Email))
            {
                throw new OurException($"This email {request.Email} is already existed!");
            }

            var Project = new Domain.Models.Project(request.Name, request.Email, request.Address, request.Age, request.PhoneNumber);

            _ProjectRepository.Add(Project);

            if (await _ProjectRepository.SaveChangesAsync() == 0)
            {
                throw new OurException("Project not created");
            }

            await _mediator.Publish(new Domain.Events.ProjectCreatedEvent(Project.Id), cancellationToken);

            var ProjectDto = _ProjectDxos.MapProjectDto(Project);
            return ProjectDto;
        }
    }
}