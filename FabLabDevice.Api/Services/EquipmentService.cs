using AutoMapper;
using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Repositories;
using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Exceptions;
using FabLabDevice.Api.Resource.Equipments;

namespace FabLabDevice.Api.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IEquipmentTypeRepository _equipmentTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, ILocationRepository locationRepository, ISupplierRepository supplierRepository, IEquipmentTypeRepository equipmentTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _locationRepository = locationRepository;
            _supplierRepository = supplierRepository;
            _equipmentTypeRepository = equipmentTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EquipmentViewModel>> GetAllEquipments()
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentViewModel>>(equipments);
        }

        public async Task<bool> AddEquipment(CreateEquipmentViewModel viewModel)
        {
            var equipment = _mapper.Map<CreateEquipmentViewModel, Equipment>(viewModel);
            equipment.Location = await _locationRepository.GetAsync(viewModel.LocationId) ?? throw new ResourceNotFoundException(nameof(Location), viewModel.LocationId);
            equipment.Supplier = await _supplierRepository.GetAsync(viewModel.SupplierName) ?? throw new ResourceNotFoundException(nameof(Supplier), viewModel.SupplierName);
            equipment.EquipmentType = await _equipmentTypeRepository.GetAsync(viewModel.EquipmentTypeId) ?? throw new ResourceNotFoundException(nameof(EquipmentType), viewModel.EquipmentId);
            //equipment.AddNavigations(location, supplier, equipmentType);

            await _equipmentRepository.AddAsync(equipment);

            return await _unitOfWork.CompleteAsync();
        }
    }
}
