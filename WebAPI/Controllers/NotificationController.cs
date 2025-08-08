using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.NotificationDto;
using Web.EntityLayer.Entities;

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
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification
            {
                Type = createNotificationDto.Type,
                Icon = createNotificationDto.Icon,
                Description = createNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false,
            };
            _notificationService.TAdd(notification);
            return Ok("Bildirim Ekleme İşlemi Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var notification = _notificationService.TGetById(id);
            _notificationService.TDelete(notification);
            return Ok("Bildirim Silinme İşlemi Yapıldı");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var notification = _notificationService.TGetById(id);
            return Ok(notification);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Description = updateNotificationDto.Description,
                Date = updateNotificationDto.Date,
                Status = updateNotificationDto.Status
            };
            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncelleme İşlemi Yapıldı");
        }
        [HttpGet("NotificationStatusChangeTrue/{id}")]
        public IActionResult NotificationStatusChangeTrue(int id)
        {
            _notificationService.TNotificationStatusChangeTrue(id);
            return Ok("Bildirim Durumu True Olarak Güncellendi");
        }
        [HttpGet("NotificationStatusChangeFalse/{id}")]
        public IActionResult NotificationStatusChangeFalse(int id)
        {
            _notificationService.TNotificationStatusChangeFalse(id);
            return Ok("Bildirim Durumu False Olarak Güncellendi");
        }
    }
}
