using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messaageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMessageList()
        {
            var messageList = _mapper.Map<List<ResultMessageDto>>(_messaageService.TGetAll());
            return Ok(messageList);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            createMessageDto.MessageDate = DateTime.Now;
            var message = _mapper.Map<Message>(createMessageDto);
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
            var message = _mapper.Map<Message>(updateMessageDto);
            _messaageService.TUpdate(message);
            return Ok("Mesaj başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _mapper.Map<GetMessageDto>(_messaageService.TGetById(id));
            return Ok(value);
        }
    }
}
