using System;
using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Models.PackageType;
using CourierManagementAPI.Services.PackageTypes;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementAPI.Controllers.PackageTypes
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class PackageTypesController : BaseController.BaseController
    {

        private readonly IPackageTypesService _service;


        public PackageTypesController(IPackageTypesService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("savePackageType")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreatePackageType(PackageType U)
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
        [ActionName("getPackageTypes")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatPackageTypes()
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
        [ActionName("getPackageType")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatPackageType([FromRoute] int id)
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
