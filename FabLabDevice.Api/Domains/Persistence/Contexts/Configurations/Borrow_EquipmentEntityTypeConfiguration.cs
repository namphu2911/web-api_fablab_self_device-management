using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class Borrow_EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Borrow_Equipment>
    {
        public void Configure(EntityTypeBuilder<Borrow_Equipment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Equipment).WithMany(i => i.BorrowEquipments).HasForeignKey(x => x.EquipmentId);
            builder.HasOne(x => x.Borrow).WithMany(i => i.BorrowEquipments).HasForeignKey(x => x.BorrowId);
        }
    }
}
