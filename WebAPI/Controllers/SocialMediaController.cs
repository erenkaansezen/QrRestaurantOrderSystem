using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.SocialMediaDto;
using Web.DtoLayer.TestimonialDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var media = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(media);
            return Ok("Sosyal medya bilgisi başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal medya bilgisi başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var media = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            return Ok(media);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var media = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(media);
            return Ok("Sosyal medya bilgisi başarıyla güncellendi");

        }
    }
}
