using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.AboutDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(about);
            return Ok("Hakkında kısımı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkında kısımı başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var about = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(about);
            return Ok("Hakkında kısımı başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _mapper.Map<GetAboutDto>(_aboutService.TGetById(id));
            return Ok(value);
        }
    }
}
