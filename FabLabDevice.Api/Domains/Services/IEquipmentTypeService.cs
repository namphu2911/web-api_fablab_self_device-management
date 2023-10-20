using FabLabDevice.Api.Resource.EquipmentTypes;

namespace FabLabDevice.Api.Domains.Services
{
    public interface IEquipmentTypeService
    {
        public Task<List<EquipmentTypeViewModel>> GetAllEquipmentTypes();
        public Task<EquipmentTypeViewModel> GetEquipmentTypeById(string equipmentTypeId);
        public Task<bool> AddEquipmentType(CreateEquipmentTypeViewModel viewModel);
        public Task<bool> UpdateEquipmentType(string equipmentTypeId, UpdateEquipmentTypeViewModel viewModel);
        public Task<bool> DeleteEquipmentType(string equipmentTypeId);
    }
}
