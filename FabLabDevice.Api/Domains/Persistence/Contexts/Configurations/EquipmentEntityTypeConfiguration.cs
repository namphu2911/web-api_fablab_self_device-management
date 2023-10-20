using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(x => x.EquipmentId);

            builder.Property(x => x.EquipmentName).IsRequired();
            builder.Property(x => x.YearOfSupply).IsRequired();
            builder.Property(x => x.CodeOfManage).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(i => i.SupplierName);
            builder.HasOne(x => x.EquipmentType).WithMany().HasForeignKey(i => i.EquipmentTypeId);

            builder.HasMany(x => x.BorrowEquipments).WithOne(x => x.Equipment);

        }
    }
}
