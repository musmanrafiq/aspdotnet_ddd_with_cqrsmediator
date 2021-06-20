using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class ProjectDbContext : DbContext
    {
        
        public DbSet<Domain.Models.Project> Projects { get; set; }
        
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations<ProjectDbContext>();
        }

        public override int SaveChanges()
        {
            this.AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}