using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.DiscountDto;
using Web.DtoLayer.FeatureDto;
using Web.DtoLayer.SliderDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var slider = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(slider);
            return Ok("Slider başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan bilgisi başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var slider = _mapper.Map<Web.DtoLayer.SliderDto.GetSliderDto>(_sliderService.TGetById(id));
            return Ok(slider);
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var slider = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(slider);
            return Ok("Öne Çıkan bilgisi başarıyla güncellendi");

        }
    }
}
