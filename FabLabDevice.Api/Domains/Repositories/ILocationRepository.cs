using FabLabDevice.Api.Domains.Models;

namespace FabLabDevice.Api.Domains.Repositories
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAllAsync();
        public Task<Location?> GetAsync(string locationId);
        public Task<Location> AddAsync(Location location);
        public Location Update(Location location);
        public Task DeleteAsync(string locationId);
        public Task<bool> ExistsAsync(string locationId);
    }
}
