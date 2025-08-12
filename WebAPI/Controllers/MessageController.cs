using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.MessageDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messaageService;

        public MessageController(IMessageService messageService)
        {
            _messaageService = messageService;
        }

        [HttpGet]
        public IActionResult GetMessageList()
        {
            var values = _messaageService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message
            {
                NameSurname = createMessageDto.NameSurname,
                Mail = createMessageDto.Mail,
                PhoneNumber = createMessageDto.PhoneNumber,
                Subject = createMessageDto.Subject,
                Content = createMessageDto.Content,
                MessageDate = createMessageDto.MessageDate,
                Status = createMessageDto.Status
            };
            _messaageService.TAdd(message);
            return Ok("Mesaj başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messaageService.TGetById(id);
            _messaageService.TDelete(value);
            return Ok("Mesaj başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message
            {
                MessageID = updateMessageDto.MessageID,
                NameSurname = updateMessageDto.NameSurname,
                Mail = updateMessageDto.Mail,
                PhoneNumber = updateMessageDto.PhoneNumber,
                Subject = updateMessageDto.Subject,
                Content = updateMessageDto.Content,
                MessageDate = updateMessageDto.MessageDate,
                Status = updateMessageDto.Status
            };
            _messaageService.TUpdate(message);
            return Ok("Mesaj başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messaageService.TGetById(id);
            return Ok(value);
        }
    }
}
