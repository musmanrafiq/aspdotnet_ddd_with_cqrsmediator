using System;
using System.Threading.Tasks;
using Project.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Project.Data.Repositories
{
    public class ProjectRepository : Repository<Domain.Models.Project>, IProjectRepository
    {
        public ProjectRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> EmailExistAsync(string email)
        {
           return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Email == email);

        }
    }
}