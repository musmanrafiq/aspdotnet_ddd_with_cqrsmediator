using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Data.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Domain.Models.Project>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Project_id").HasDefaultValueSql("newId()");

            builder.Property(b => b.Name).HasColumnName("Project_name").HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Age).HasColumnName("age").IsRequired();

            builder.Property(b => b.Address).HasColumnName("address").HasMaxLength(255).IsRequired();

            builder.Property(b => b.Email).HasColumnName("email").HasMaxLength(255).IsRequired();

            builder.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasMaxLength(20).IsRequired();

            builder.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired();

            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at").IsRequired();
        }
    }
}