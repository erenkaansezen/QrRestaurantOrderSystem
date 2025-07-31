using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sliders = _sliderService.TGetAll();
            return Ok(sliders);
        }
    }
}
