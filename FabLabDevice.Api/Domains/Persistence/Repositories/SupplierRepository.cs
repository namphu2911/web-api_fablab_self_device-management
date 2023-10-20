using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Persistence.Contexts;
using FabLabDevice.Api.Domains.Persistence.Exceptions;
using FabLabDevice.Api.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FabLabDevice.Api.Domains.Persistence.Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(FabLabDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string supplierName)
        {
            return await _context.Suppliers
                .AnyAsync(x => x.SupplierName == supplierName);
        }

        public async Task<Supplier> AddAsync(Supplier supplier)
        {
            if (await ExistsAsync(supplier.SupplierName))
            {
                throw new EntityDuplicationException(nameof(Supplier), supplier.SupplierName);
            }

            return _context.Suppliers
            .Add(supplier)
            .Entity;
        }

        public async Task DeleteAsync(string supplierName)
        {
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(x => x.SupplierName == supplierName);
            if (supplier is not null)
            {
                _context.Suppliers.Remove(supplier);
            }
        }

        
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers
                .ToListAsync();
        }

        public async Task<Supplier?> GetAsync(string supplierName)
        {
            return await _context.Suppliers
                .FirstOrDefaultAsync(x => x.SupplierName == supplierName);
        }

        public Supplier Update(Supplier supplier)
        {
            return _context.Suppliers
                    .Update(supplier)
                    .Entity;
        }
    }
}
