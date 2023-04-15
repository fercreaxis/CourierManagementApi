using System;
using ApproveX_API.Controllers.ActionFilters;
using ApproveX_API.Models.Shared;
using ApproveX_API.Models.Users;
using ApproveX_API.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ApproveX_API.Controllers.Users
{

    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class UsersController : BaseController.BaseController
    {

        private readonly IUsersService _service;


        public UsersController(IUsersService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("createUser")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult CreateUser(User U)
        {
            try
            {
                var result = _service.CreateUser(U);

                result.password = "";
                result.passwordSalt = "";

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpPost]
        [ActionName("userLogin")]
        public IActionResult UserLogin(LoginRequest U)
        {
            try
            {

                var result = _service.LoginUser(U.userName, U.password, U.sessionId);

                if (result != null)
                {
                    result.password = "";
                    result.passwordSalt = "";

                    if (result.isLocked)
                    {
                        return NotFound("Account is locked");
                    }
                    return Ok(result);
                }
                else
                {
                    return NotFound("Incorrect Username or Password" );
                }
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpPost]
        [ActionName("updateUser")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult UpdateUser(User U)
        {
            try
            {
                User result = null;

                if (U.password != null)
                {
                   result = _service.UpdateUser(U, true);
                }
                else
                {
                   result = _service.UpdateUser(U, false);
                }

                result.password = "";
                result.passwordSalt = "";

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

        [HttpGet]
        [ActionName("getUsers")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatUsers()
        {
            try
            {
                var result = _service.GetUsers();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        [ActionName("getUser")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GatUser([FromRoute] int id)
        {
            try
            {
                var result = _service.GetUser(id);
                result.password = "";
                result.passwordSalt = "";
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

        [HttpGet]
        [ActionName("getUserRoles")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetUserRoles()
        {
            try
            {
                var result = _service.GetUserRoles();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

        [HttpGet]
        [ActionName("getRoleEntities")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetRoleEntities()
        {
            try
            {
                var result = _service.GetRoleEntities();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

    }
}
