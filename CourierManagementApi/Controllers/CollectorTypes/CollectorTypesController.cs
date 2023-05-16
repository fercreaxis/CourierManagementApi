using System;
using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Models.CollectorType;
using CourierManagementAPI.Services.CollectorTypes;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementAPI.Controllers.CollectorTypes
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class CollectorTypesController : BaseController.BaseController
    {

        private readonly ICollectorTypesService _service;


        public CollectorTypesController(ICollectorTypesService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveCollectorType")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreateCollectorType(CollectorType U)
        {
            try
            {
                var result = _service.Save(U, userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

        [HttpGet]
        [ActionName("getCollectorTypes")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatCollectorTypes()
        {
            try
            {
                var result = _service.GetList(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        [ActionName("getCollectorType")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatCollectorType([FromRoute] int id)
        {
            try
            {
                var result = _service.GetById(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

    }
}
