using System;
using System.IO;
using System.Linq;
using ApproveX_API.Models.Users;
using ApproveX_API.Services.Users;
using ApproveX_API.Services.UserSessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ApproveX_API.Controllers.ActionFilters

{
    public class ValidateSessionFilter : IActionFilter
    {

        private readonly IValidateSessionService _service;
        private readonly IUsersService _usersService;


        public ValidateSessionFilter(IValidateSessionService Param, IUsersService UsersService)
        {
            this._service = Param; // Dependency Injection
            _usersService = UsersService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext Context)
        {
            //Header Values
            try
            {
                

                var userId = Convert.ToInt32(Context.HttpContext.Request.Headers["userId"].ToString() ?? "0");
                string token = Context.HttpContext.Request.Headers["token"];
                string sessionId = Context.HttpContext.Request.Headers["sessionId"];

                token = token.Replace("Bearer ", "");

                var result = _service.ValidateSession(userId, sessionId, token);

                switch (result)
                {
                    case -1:
                        Context.Result = new UnauthorizedObjectResult("Session doesn't exists");
                        break;
                    case 0:
                        Context.Result = new UnauthorizedObjectResult("Session expired");
                        break;
                    case 1:
                        //Do nothing, session is valid
                        break;
                    default:
                        Context.Result = new UnauthorizedObjectResult("Session doesn't exists");
                        break;
                }

                var args = Context.ActionArguments;

                var param = JsonConvert.SerializeObject(args);



                if (userId == 0) return;

                var activity = new UserActivity
                {
                    userId = userId,
                    url = Context.HttpContext.Request.Path.Value,
                    ipAddress = Context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    action = @$"Method: {Context.HttpContext.Request.Method} - Path: {Context.HttpContext.Request.Path.Value}  - Response Code: {Context.HttpContext.Response.StatusCode.ToString()}",
                    parameters = param

                };
                _usersService.LogUserActivity(activity);

            }
            catch (Exception ex)
            {
                Context.Result = new UnauthorizedObjectResult(new { text = "Session doesn't exists", error = ex.Message, innerEx = ex.InnerException });

            }
        }
    }
}
