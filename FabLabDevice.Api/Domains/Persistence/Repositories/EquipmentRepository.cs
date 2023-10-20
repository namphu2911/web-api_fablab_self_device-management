using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Persistence.Contexts;
using FabLabDevice.Api.Domains.Persistence.Exceptions;
using FabLabDevice.Api.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FabLabDevice.Api.Domains.Persistence.Repositories
{
    public class EquipmentRepository : BaseRepository, IEquipmentRepository
    {
        public EquipmentRepository(FabLabDbContext context) : base(context)
        {
        }

        public async Task<Equipment> AddAsync(Equipment equipment)
        {
            if (await ExistsAsync(equipment.EquipmentId))
            {
                throw new EntityDuplicationException(nameof(Equipment), equipment.EquipmentId);
            }

            return _context.Equipments
                .Add(equipment)
                .Entity;
        }

        public Task DeleteAsync(string equipmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(string equipmentId)
        {
            return await _context.Equipments
                .AnyAsync(x => x.EquipmentId == equipmentId);
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments
                .Include(x => x.EquipmentType)
                .Include(x => x.Location)
                .Include(x => x.Supplier)
                .ToListAsync();
        }

        public Task<Equipment?> GetAsync(string equipmentId)
        {
            throw new NotImplementedException();
        }

        public Equipment Update(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}
