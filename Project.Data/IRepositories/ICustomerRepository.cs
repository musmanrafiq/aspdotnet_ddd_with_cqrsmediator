using System.Threading.Tasks;

namespace Project.Data.IRepositories
{
    public interface IProjectRepository : IRepository<Domain.Models.Project>
    {
       Task<bool> EmailExistAsync(string email);
    }
}