using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Persistence.Contexts;
using FabLabDevice.Api.Domains.Persistence.Exceptions;
using FabLabDevice.Api.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FabLabDevice.Api.Domains.Persistence.Repositories
{
    public class EquipmentTypeRepository : BaseRepository, IEquipmentTypeRepository
    {
        public EquipmentTypeRepository(FabLabDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string equipmentTypeId)
        {
            return await _context.EquipmentTypes
                .AnyAsync(x => x.EquipmentTypeId == equipmentTypeId);
        }

        public async Task<IEnumerable<EquipmentType>> GetAllAsync()
        {
            return await _context.EquipmentTypes
                .ToListAsync();
        }

        public async Task<EquipmentType?> GetAsync(string equipmentTypeId)
        {
            return await _context.EquipmentTypes
                .FirstOrDefaultAsync(x => x.EquipmentTypeId == equipmentTypeId);
        }

        public EquipmentType Update(EquipmentType equipmentType)
        {
            return _context.EquipmentTypes
                    .Update(equipmentType)
                    .Entity;
        }

        public async Task<EquipmentType> AddAsync(EquipmentType equipmentType)
        {
            if (await ExistsAsync(equipmentType.EquipmentTypeId))
            {
                throw new EntityDuplicationException(nameof(EquipmentType), equipmentType.EquipmentTypeId);
            }

            return _context.EquipmentTypes
            .Add(equipmentType)
            .Entity;
        }

        public async Task DeleteAsync(string equipmentTypeId)
        {
            var equipmentType = await _context.EquipmentTypes
                .FirstOrDefaultAsync(x => x.EquipmentTypeId == equipmentTypeId);
            if (equipmentType is not null)
            {
                _context.EquipmentTypes.Remove(equipmentType);
            }
        }

    }
}
