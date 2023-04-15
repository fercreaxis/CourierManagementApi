using ApproveX_API.Controllers.ActionFilters;
using ApproveX_API.Services.Devices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApproveX_API.Controllers.Device
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class DeviceController : BaseController.BaseController
    {
        private readonly IDeviceService _service;


        public DeviceController(IDeviceService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveDevice")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult SaveDevice(Models.Devices.Device device)
        {
            try
            {
                var result = _service.SaveDevice(device, base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        [ActionName("getDeviceByToken")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetDeviceByToken([FromQuery] Guid id)
        {
            try
            {
                var result = _service.GetByToken(id, base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }


        [HttpGet]
        [ActionName("getDeviceById")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetDeviceById([FromRoute] int id)
        {
            try
            {
                var result = _service.GetById(id, base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        [ActionName("getDevices")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetDevices()
        {
            try
            {
                var result = _service.GetDevices(base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
    }
}
