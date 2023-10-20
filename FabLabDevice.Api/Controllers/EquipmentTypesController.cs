using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Messages;
using FabLabDevice.Api.Resource.EquipmentTypes;
using Microsoft.AspNetCore.Mvc;

namespace FabLabDevice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentTypesController : Controller
    {
        private readonly IEquipmentTypeService _equipmentTypeService;

        public EquipmentTypesController(IEquipmentTypeService equipmentTypeService)
        {
            _equipmentTypeService = equipmentTypeService;
        }

        [HttpGet]
        public async Task<List<EquipmentTypeViewModel>> GetAllEquipmentTypes()
        {
            return await _equipmentTypeService.GetAllEquipmentTypes();
        }

        [HttpGet]
        [Route("{equipmentTypeId}")]
        public async Task<EquipmentTypeViewModel> GetEquipmentTypeById([FromRoute] string equipmentTypeId)
        {
            return await _equipmentTypeService.GetEquipmentTypeById(equipmentTypeId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentType([FromBody] CreateEquipmentTypeViewModel equipmentType)
        {
            try
            {
                var result = await _equipmentTypeService.AddEquipmentType(equipmentType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPut]
        [Route("{equipmentTypeId}")]
        public async Task<IActionResult> UpdateEquipmentType([FromRoute] string equipmentTypeId, [FromBody] UpdateEquipmentTypeViewModel equipmentType)
        {
            try
            {
                var result = await _equipmentTypeService.UpdateEquipmentType(equipmentTypeId, equipmentType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete]
        [Route("{equipmentTypeId}")]
        public async Task<IActionResult> DeleteEquipmentType([FromRoute] string equipmentTypeId)
        {
            try
            {
                var result = await _equipmentTypeService.DeleteEquipmentType(equipmentTypeId);
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
