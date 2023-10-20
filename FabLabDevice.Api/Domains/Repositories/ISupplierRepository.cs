using FabLabDevice.Api.Domains.Models;

namespace FabLabDevice.Api.Domains.Repositories
{
    public interface ISupplierRepository
    {
        public Task<IEnumerable<Supplier>> GetAllAsync();
        public Task<Supplier?> GetAsync(string supplierName);
        public Task<Supplier> AddAsync(Supplier supplier);
        public Supplier Update(Supplier supplier);
        public Task DeleteAsync(string supplierName);
        public Task<bool> ExistsAsync(string supplierName);
    }
}
