using Project.Domain.Dtos;

namespace Project.Service.Dxos
{
    public interface IProjectDxos
    {
        ProjectDto MapProjectDto(Domain.Models.Project Project);
    }
}