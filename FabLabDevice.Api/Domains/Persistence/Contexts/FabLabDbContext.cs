using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Persistence.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FabLabDevice.Api.Domains.Persistence.Contexts
{
    public class FabLabDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Borrow_Equipment> BorrowsEquipments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }

        public FabLabDbContext(DbContextOptions<FabLabDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Borrow_EquipmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentTypeEntityTypeConfiguration());
        }
    }
}
