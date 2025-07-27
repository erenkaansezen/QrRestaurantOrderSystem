using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet("GetTotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {
            var totalOrderCount = _orderService.TTotalOrderCount();
            return Ok(totalOrderCount);
        }
        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            var activeOrderCount = _orderService.TActiveOrderCount();
            return Ok(activeOrderCount);
        }
        [HttpGet("TLastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var lastOrderPrice = _orderService.TLastOrderPrice();
            return Ok(lastOrderPrice);
        }
        
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var lastOrderPrice = _orderService.TTodayTotalPrice();
            return Ok(lastOrderPrice);
        }
    }
}
