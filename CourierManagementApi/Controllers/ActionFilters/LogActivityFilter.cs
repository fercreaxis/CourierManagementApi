using System;
using System.IO;
using ApproveX_API.Models.Users;
using ApproveX_API.Services.Users;
using ApproveX_API.Services.UserSessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ApproveX_API.Controllers.ActionFilters
{
    public class LogActivityFilter : IActionFilter
    {
        private readonly IValidateSessionService _service;
        private readonly IUsersService _usersService;


        public LogActivityFilter(IValidateSessionService Param, IUsersService UsersService)
        {
            this._service = Param; // Dependency Injection
            _usersService = UsersService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext Context)
        {
            try
            {
                var cont = Context.HttpContext.Request.Path;
                var userId = Convert.ToInt32(Context.HttpContext.Request.Headers["fromUserId"].ToString() ?? "0");

                var args = Context.ActionArguments;

                var param = JsonConvert.SerializeObject(args);

                var activity = new UserActivity
                {
                    userId = userId,
                    url = Context.HttpContext.Request.Path.Value,
                    ipAddress = Context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    action = @$"Method: {Context.HttpContext.Request.Method} - Path: {Context.HttpContext.Request.Path.Value} - Response Code: {Context.HttpContext.Response.StatusCode.ToString()} ",
                    parameters = param

                };
                _usersService.LogUserActivity(activity);
            }
            catch
            {
                throw;
            }
        }
    }
}
