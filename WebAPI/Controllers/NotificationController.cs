using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            var notifications = _notificationService.TGetAll();
            return Ok(notifications);
        }
        [HttpGet("count")]
        public IActionResult GetNotificationCountStatusFalse()
        {
            var count = _notificationService.TNotificationCountStatusFalse();
            return Ok(count);
        }
        [HttpGet("status-false")]
        public IActionResult GetAllNotificationsByStatusFalse()
        {
            var notifications = _notificationService.TGetAllNotificationsByStatusFalse();
            return Ok(notifications);
        }
    }
}
