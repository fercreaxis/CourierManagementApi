using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApproveX_API.Controllers.BaseController
{
    public class BaseController : Controller
    {
        public int userId
        {
            get
            {
                try
                {
                    return Convert.ToInt32(HttpContext.Request.Headers["userId"]);
                }
                catch (System.Exception)
                {
                    return 0;   
                }
            }
        }


    }
}
