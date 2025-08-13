using AutoMapper;
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
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            var notifications = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetAll());
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
            createNotificationDto.Status = false; // Yeni bildirimler başlangıçta false olarak ayarlanır
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var notification = _mapper.Map<Notification>(createNotificationDto);
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
            var notification = _mapper.Map<Notification>(updateNotificationDto);    
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
