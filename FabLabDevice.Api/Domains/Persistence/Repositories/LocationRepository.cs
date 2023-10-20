using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Persistence.Contexts;
using FabLabDevice.Api.Domains.Persistence.Exceptions;
using FabLabDevice.Api.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FabLabDevice.Api.Domains.Persistence.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(FabLabDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string locationId)
        {
            return await _context.Locations
                .AnyAsync(x => x.LocationId == locationId);
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations
                .ToListAsync();
        }

        public async Task<Location?> GetAsync(string locationId)
        {
            return await _context.Locations
                .FirstOrDefaultAsync(x => x.LocationId == locationId);
        }

        public async Task<Location> AddAsync(Location location)
        {
            if (await ExistsAsync(location.LocationId))
            {
                throw new EntityDuplicationException(nameof(Location), location.LocationId);
            }

            return _context.Locations
            .Add(location)
            .Entity;
        }

        public Location Update(Location location)
        {
            return _context.Locations
                    .Update(location)
                    .Entity;
        }

        public async Task DeleteAsync(string locationId)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(x => x.LocationId == locationId);
            if (location is not null)
            {
                _context.Locations.Remove(location);
            }
        }
    }
}
