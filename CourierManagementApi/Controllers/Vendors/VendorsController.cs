using System;
using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Models.Vendor;
using CourierManagementAPI.Services.Vendors;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementAPI.Controllers.Vendors
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class VendorsController : BaseController.BaseController
    {

        private readonly IVendorsService _service;


        public VendorsController(IVendorsService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveVendor")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreateVendorType(Vendor U)
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
        [ActionName("getVendors")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatVendorTypes()
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
        [ActionName("getVendor")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatVendor([FromRoute] int id)
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
