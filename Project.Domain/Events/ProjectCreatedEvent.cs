using MediatR;
using System;

namespace Project.Domain.Events
{
    public class ProjectCreatedEvent : INotification
    {
        public Guid ProjectId { get; }

        public ProjectCreatedEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}