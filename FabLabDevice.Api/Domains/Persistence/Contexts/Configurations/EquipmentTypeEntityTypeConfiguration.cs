using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class EquipmentTypeEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> builder)
        {
            builder.HasKey(x => x.EquipmentTypeId);

            builder.Property(x => x.EquipmentTypeName);
            builder.Property(x => x.Picture);
            builder.Property(x => x.Category).IsRequired();
        }
    }
}
