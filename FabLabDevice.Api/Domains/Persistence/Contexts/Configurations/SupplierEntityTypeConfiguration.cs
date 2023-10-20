using FabLabDevice.Api.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabLabDevice.Api.Domains.Persistence.Contexts.Configurations
{
    public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SupplierName);

            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
        }
    }
}
