using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.CategoryDto;
using Web.DtoLayer.ContactDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contact);
            return Ok("İletişim bilgisi başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgisi başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _mapper.Map<GetContactDto>(_contactService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(contact);
            return Ok("İletişim bilgisi başarıyla güncellendi");

        }
    }
}
