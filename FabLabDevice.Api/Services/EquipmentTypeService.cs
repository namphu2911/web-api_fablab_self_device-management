using AutoMapper;
using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Repositories;
using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Exceptions;
using FabLabDevice.Api.Resource.EquipmentTypes;

namespace FabLabDevice.Api.Services
{
    public class EquipmentTypeService : IEquipmentTypeService
    {
        private readonly IEquipmentTypeRepository _equipmentTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _equipmentTypeRepository = equipmentTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EquipmentTypeViewModel>> GetAllEquipmentTypes()
        {
            var equipmentTypes = await _equipmentTypeRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentTypeViewModel>>(equipmentTypes);
        }

        public async Task<EquipmentTypeViewModel> GetEquipmentTypeById(string equipmentTypeId)
        {
            var equipmentType = await _equipmentTypeRepository.GetAsync(equipmentTypeId) ?? throw new ResourceNotFoundException(nameof(EquipmentType), equipmentTypeId);
            return _mapper.Map<EquipmentTypeViewModel>(equipmentType);
        }

        public async Task<bool> AddEquipmentType(CreateEquipmentTypeViewModel viewModel)
        {
            var equipmentType = _mapper.Map<CreateEquipmentTypeViewModel, EquipmentType>(viewModel);
            await _equipmentTypeRepository.AddAsync(equipmentType);

            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteEquipmentType(string equipmentTypeId)
        {
            await _equipmentTypeRepository.DeleteAsync(equipmentTypeId);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateEquipmentType(string equipmentTypeId, UpdateEquipmentTypeViewModel viewModel)
        {
            var equipmentType = await _equipmentTypeRepository.GetAsync(equipmentTypeId) ?? throw new ResourceNotFoundException(nameof(EquipmentType), equipmentTypeId);

            equipmentType.Update(viewModel.Picture, viewModel.EquipmentTypeName, viewModel.Category);
            _equipmentTypeRepository.Update(equipmentType);

            return await _unitOfWork.CompleteAsync();
        }
    }
}
