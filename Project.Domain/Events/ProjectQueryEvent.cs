using MediatR;
using System;

namespace Project.Domain.Events
{
    public class ProjectQueryEvent : INotification
    {
        public Guid ProjectId { get; }

        public ProjectQueryEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}