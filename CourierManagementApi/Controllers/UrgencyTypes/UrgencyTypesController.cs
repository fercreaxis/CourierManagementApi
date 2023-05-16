using System;
using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Models.UrgencyType;
using CourierManagementAPI.Services.UrgencyTypes;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementAPI.Controllers.UrgencyTypes
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class UrgencyTypesController : BaseController.BaseController
    {

        private readonly IUrgencyTypesService _service;


        public UrgencyTypesController(IUrgencyTypesService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveUrgencyType")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreateUrgencyType(UrgencyType U)
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
        [ActionName("getUrgencyTypes")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatUrgencyTypes()
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
        [ActionName("getUrgencyType")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatUrgencyType([FromRoute] int id)
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
