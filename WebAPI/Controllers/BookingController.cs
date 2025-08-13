using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.BookingDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _createBookingValidator;
        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> createBookingValidator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _createBookingValidator = createBookingValidator;
        }

        [HttpGet]
        public IActionResult GetBookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _createBookingValidator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var booking = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon kaldırıldı");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var booking = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _mapper.Map<GetBookingDto>(_bookingService.TGetById(id));
            return Ok(value);

        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon onaylandı");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.BookingStatusCancelled(id);
            return Ok("Rezervasyon iptal edildi");
        }
    }
}
