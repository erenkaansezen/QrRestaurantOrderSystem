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

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult GetAboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About
            {
                ImageUrl = createAboutDto.ImageUrl,
                Title = createAboutDto.Title,
                Description = createAboutDto.Description
            };
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
            About about = new About
            {
                AboutID = updateAboutDto.AboutID,
                ImageUrl = updateAboutDto.ImageUrl,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkında kısımı başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
