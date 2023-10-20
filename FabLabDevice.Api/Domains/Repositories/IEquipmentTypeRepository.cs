using FabLabDevice.Api.Domains.Models;

namespace FabLabDevice.Api.Domains.Repositories
{
    public interface IEquipmentTypeRepository
    {
        public Task<IEnumerable<EquipmentType>> GetAllAsync();
        public Task<EquipmentType?> GetAsync(string equipmentTypeId);
        public Task<EquipmentType> AddAsync(EquipmentType equipmentType);
        public EquipmentType Update(EquipmentType equipmentType);
        public Task DeleteAsync(string equipmentTypeId);
        public Task<bool> ExistsAsync(string equipmentTypeId);
    }
}
