using AutoMapper;
using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Domains.Repositories;
using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Exceptions;
using FabLabDevice.Api.Resource.Locations;

namespace FabLabDevice.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LocationViewModel>> GetAllLocations()
        {
            var locations = await _locationRepository.GetAllAsync();
            return _mapper.Map<List<LocationViewModel>>(locations);
        }

        public async Task<LocationViewModel> GetLocationById(string locationId)
        {
            var location = await _locationRepository.GetAsync(locationId) ?? throw new ResourceNotFoundException(nameof(Location), locationId);
            return _mapper.Map<LocationViewModel>(location);
        }

        public async Task<bool> AddLocation(CreateLocationViewModel viewModel)
        {
            var location = _mapper.Map<CreateLocationViewModel, Location>(viewModel);
            await _locationRepository.AddAsync(location);

            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteLocation(string locationId)
        {
            await _locationRepository.DeleteAsync(locationId);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateLocation(string locationId, UpdateLocationViewModel viewModel)
        {
            var location = await _locationRepository.GetAsync(locationId) ?? throw new ResourceNotFoundException(nameof(Location), locationId);

            location.Update(viewModel.Note);
            _locationRepository.Update(location);

            return await _unitOfWork.CompleteAsync();
        }
    }
}
