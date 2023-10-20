using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Messages;
using FabLabDevice.Api.Resource.Equipments;
using Microsoft.AspNetCore.Mvc;

namespace FabLabDevice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<List<EquipmentViewModel>> GetAllEquipments()
        {
            return await _equipmentService.GetAllEquipments();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromBody] CreateEquipmentViewModel equipment)
        {
            try
            {
                var result = await _equipmentService.AddEquipment(equipment);
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
