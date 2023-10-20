using FabLabDevice.Api.Resource.Suppliers;

namespace FabLabDevice.Api.Domains.Services
{
    public interface ISupplierService
    {
        public Task<List<SupplierViewModel>> GetAllSuppliers();
        public Task<SupplierViewModel> GetSupplierByName(string supplierName);
        public Task<bool> AddSupplier(CreateSupplierViewModel createSupplierViewModel);
        public Task<bool> UpdateSupplier(string supplierName, UpdateSupplierViewModel updateSupplierViewModel);
        public Task<bool> DeleteSupplier(string supplierName);
    }
}
