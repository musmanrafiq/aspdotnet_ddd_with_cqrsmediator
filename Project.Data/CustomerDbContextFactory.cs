using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class ProjectDbContextFactory : DesignTimeDbContextFactory<ProjectDbContext>
    {
        protected override ProjectDbContext CreateNewInstance(DbContextOptions<ProjectDbContext> options)
        {
            return new ProjectDbContext(options);
        }
    }
}