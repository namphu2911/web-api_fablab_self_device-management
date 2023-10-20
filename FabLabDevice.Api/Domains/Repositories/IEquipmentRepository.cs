using FabLabDevice.Api.Domains.Models;

namespace FabLabDevice.Api.Domains.Repositories
{
    public interface IEquipmentRepository
    {
        public Task<IEnumerable<Equipment>> GetAllAsync();
        public Task<Equipment?> GetAsync(string equipmentId);
        public Task<Equipment> AddAsync(Equipment equipment);
        public Equipment Update(Equipment equipment);
        public Task DeleteAsync(string equipmentId);
        public Task<bool> ExistsAsync(string equipmentId);
    }
}
