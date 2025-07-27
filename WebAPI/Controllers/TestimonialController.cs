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
            _testimonialService.TAdd(new Testimonial()
            {
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
                Title = createTestimonialDto.Title
                

            });
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
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimoinal(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Name = updateTestimonialDto.Name,
                Status = updateTestimonialDto.Status,
                Title = updateTestimonialDto.Title


            });
            return Ok("Yorum bilgisi başarıyla güncellendi");

        }
    }
}
