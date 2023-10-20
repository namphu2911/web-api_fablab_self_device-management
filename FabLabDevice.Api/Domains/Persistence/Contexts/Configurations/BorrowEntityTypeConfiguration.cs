using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class BorrowEntityTypeConfiguration : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasKey(x => x.BorrowId);

            builder.Property(x => x.BorrowedDate).IsRequired();
            builder.Property(x => x.ReturnedDate).IsRequired();
            builder.Property(x => x.OnSite).IsRequired();

            builder.HasMany(x => x.BorrowEquipments).WithOne(x => x.Borrow);
        }
    }
}
