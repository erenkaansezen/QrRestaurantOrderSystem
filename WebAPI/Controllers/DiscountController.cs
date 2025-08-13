using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.ContactDto;
using Web.DtoLayer.DiscountDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var discount = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(discount);
            return Ok("İndirim Bilgisi başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim bilgisi başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var discount = _mapper.Map<GetDiscountDto>(_discountService.TGetById(id));
            return Ok(discount);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var discount = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(discount);
            return Ok("İndirim bilgisi başarıyla güncellendi");

        }
    }
}
