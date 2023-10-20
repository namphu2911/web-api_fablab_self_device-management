using FabLabDevice.Api.Domains.Repositories;
using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Extensions.Messages;
using FabLabDevice.Api.Resource.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace FabLabDevice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        
        [HttpGet]
        public async Task<List<SupplierViewModel>> GetAllSuppliers()
        {
            return await _supplierService.GetAllSuppliers();
        }

        [HttpGet]
        [Route("{supplierName}")]
        public async Task<SupplierViewModel> GetSupplierByName([FromRoute] string supplierName)
        {
            return await _supplierService.GetSupplierByName(supplierName);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierViewModel supplier)
        {
            try
            {
                var result = await _supplierService.AddSupplier(supplier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpPut]
        [Route("{supplierName}")]
        public async Task<IActionResult> UpdateSupplier([FromRoute] string supplierName, [FromBody] UpdateSupplierViewModel supplier)
        {
            try
            {
                var result = await _supplierService.UpdateSupplier(supplierName, supplier);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorMessage(ex);
                return BadRequest(errorMessage);
            }
        }

        [HttpDelete]
        [Route("{supplierName}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] string supplierName)
        {
            try
            {
                var result = await _supplierService.DeleteSupplier(supplierName);
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
