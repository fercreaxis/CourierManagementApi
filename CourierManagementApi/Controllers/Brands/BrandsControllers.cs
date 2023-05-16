using System;
using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Models.Brand;
using CourierManagementAPI.Services.Brands;
using Microsoft.AspNetCore.Mvc;
using CourierManagementAPI.Models.Brand;

namespace CourierManagementAPI.Controllers.Brands
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class BrandsController : BaseController.BaseController
    {

        private readonly IBrandsService _service;


        public BrandsController(IBrandsService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveBrand")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreateBrand(Brand U)
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
        [ActionName("getBrands")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatBrands()
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
        [ActionName("getBrand")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatBrand([FromRoute] int id)
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
