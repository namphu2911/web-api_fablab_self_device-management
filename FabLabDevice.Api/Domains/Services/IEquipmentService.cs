using FabLabDevice.Api.Resource.Equipments;

namespace FabLabDevice.Api.Domains.Services
{
    public interface IEquipmentService
    {
        public Task<List<EquipmentViewModel>> GetAllEquipments();
        public Task<bool> AddEquipment(CreateEquipmentViewModel viewModel);
    }
}
