using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.ProductDto;
using Web.DtoLayer.TestimonialDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTestimoinalList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimoinal(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonial);
            return Ok("Yorum bilgisi başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimoinal(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Yorum bilgisi başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimoinal(int id)
        {
            var testimonial = _mapper.Map<GetTestimonailDto>(_testimonialService.TGetById(id));
            return Ok(testimonial);
        }
        [HttpPut]
        public IActionResult UpdateTestimoinal(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(testimonial);
            return Ok("Yorum bilgisi başarıyla güncellendi");

        }
    }
}
