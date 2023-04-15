using ApproveX_API.Controllers.ActionFilters;
using ApproveX_API.Services.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApproveX_API.Controllers.Notification
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class NotificationController : BaseController.BaseController
    {
        private readonly INotificationService _service;


        public NotificationController(INotificationService Param)
        {
            this._service = Param; // Dependency Injection
        }

        [HttpPost]
        [ActionName("saveNotification")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult SaveNotification(Models.Notifications.Notification notification)
        {
            try
            {
                var result = _service.SaveNotification(notification, base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }

        [HttpPost]
        [ActionName("broadcastNotification")]
        //[ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult BroadcastNotification([FromRoute] Guid id)
        {
            try
            {
                var result = _service.BroadcastNotification(id, base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }


        [HttpGet]
        [ActionName("getNotificationById")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetNotificationById([FromRoute] Guid id)
        {
            try
            {
                var result = _service.GetById(id, base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }
        [HttpGet]
        [ActionName("getNotifications")]
        [ServiceFilter(typeof(ValidateSessionFilter))]
        public IActionResult GetNotifications()
        {
            try
            {
                var result = _service.GetNotifications(base.userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.ToString());
            }
        }


    }
}
