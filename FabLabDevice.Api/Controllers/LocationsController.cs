using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Messages;
using FabLabDevice.Api.Resource.Locations;
using Microsoft.AspNetCore.Mvc;

namespace FabLabDevice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<List<LocationViewModel>> GetAllLocations()
        {
            return await _locationService.GetAllLocations();
        }

        [HttpGet]
        [Route("{locationId}")]
        public async Task<LocationViewModel> GetLocationById([FromRoute] string locationId)
        {
            return await _locationService.GetLocationById(locationId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationViewModel location)
        {
            try
            {
                var result = await _locationService.AddLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPut]
        [Route("{locationId}")]
        public async Task<IActionResult> UpdateLocation([FromRoute] string locationId, [FromBody] UpdateLocationViewModel location)
        {
            try
            {
                var result = await _locationService.UpdateLocation(locationId, location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete]
        [Route("{locationId}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] string locationId)
        {
            try
            {
                var result = await _locationService.DeleteLocation(locationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
