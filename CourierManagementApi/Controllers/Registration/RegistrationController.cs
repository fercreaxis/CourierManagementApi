using ApproveX_API.Controllers.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApproveX_API.Models;
using ApproveX_API.Services.Devices;

namespace ApproveX_API.Controllers.Registration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : BaseController.BaseController
    {

        private readonly IDeviceService _service;


        public RegistrationController(IDeviceService Param)
        {
            this._service = Param; // Dependency Injection
        }


        [HttpPost]
        [ActionName("register")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult Register([FromBody] Models.Registration.Registration registration)
        {
            try
            {
                var device = new Models.Devices.Device
                {
                    token = registration.token,
                    userId = base.userId,
                    deviceName = registration.deviceName,
                    active = true
                };

                return Ok(_service.SaveDevice(device, userId));
                //return Ok(registration.token);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
    }
}
