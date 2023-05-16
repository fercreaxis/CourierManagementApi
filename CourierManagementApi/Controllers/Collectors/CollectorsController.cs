using System;
using CourierManagementAPI.Models.Shared;
using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Models.Collector;
using CourierManagementAPI.Services.Collectors;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementAPI.Controllers.Collectors
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class CollectorsController : BaseController.BaseController
    {

        private readonly ICollectorsService _service;


        public CollectorsController(ICollectorsService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveCollector")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreateCollector(Collector U)
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
        [ActionName("getCollectors")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatCollectors()
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
        [ActionName("getCollector")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatCollector([FromRoute] int id)
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
