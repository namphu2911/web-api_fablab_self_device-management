using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectName);

            builder.Property(x => x.StartDay).IsRequired();
            builder.Property(x => x.EndDay).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Approved).IsRequired();

            builder.HasMany(x => x.Borrows).WithOne(x => x.Project);
        }
    }
}
