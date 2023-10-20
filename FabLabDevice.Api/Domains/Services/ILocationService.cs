using FabLabDevice.Api.Resource.Locations;

namespace FabLabDevice.Api.Domains.Services
{
    public interface ILocationService
    {
        public Task<List<LocationViewModel>> GetAllLocations();
        public Task<LocationViewModel> GetLocationById(string locationId);
        public Task<bool> AddLocation(CreateLocationViewModel viewModel);
        public Task<bool> UpdateLocation(string locationId, UpdateLocationViewModel viewModel);
        public Task<bool> DeleteLocation(string locationId);
    }
}
