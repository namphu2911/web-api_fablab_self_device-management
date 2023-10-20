using AutoMapper;
using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Repositories;
using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Exceptions;
using FabLabDevice.Api.Resource.Suppliers;

namespace FabLabDevice.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SupplierViewModel>> GetAllSuppliers()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return _mapper.Map<List<SupplierViewModel>>(suppliers);
        }

        public async Task<SupplierViewModel> GetSupplierByName(string supplierName)
        {
            var supplier = await _supplierRepository.GetAsync(supplierName) ?? throw new ResourceNotFoundException(nameof(Supplier), supplierName);
            return _mapper.Map<SupplierViewModel>(supplier);
        }

        public async Task<bool> AddSupplier(CreateSupplierViewModel createSupplierViewModel)
        {
            var supplier = _mapper.Map<CreateSupplierViewModel, Supplier>(createSupplierViewModel);
            await _supplierRepository.AddAsync(supplier);

            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteSupplier(string supplierName)
        {
            await _supplierRepository.DeleteAsync(supplierName);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateSupplier(string supplierName, UpdateSupplierViewModel updateSupplierViewModel)
        {
            var supplier = await _supplierRepository.GetAsync(supplierName) ?? throw new ResourceNotFoundException(nameof(Supplier), supplierName);

            supplier.Update(updateSupplierViewModel.Address, updateSupplierViewModel.PhoneNumber);
            _supplierRepository.Update(supplier);

            return await _unitOfWork.CompleteAsync();
        }
    }
}
