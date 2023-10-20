using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.LocationId);
            builder.Property(x => x.Note);
        }
    }
}
