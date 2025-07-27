using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("GetTotalMenuTableCount")]
        public IActionResult GetTotalMenuTableCount()
        {
            var totalMenuTableCount = _menuTableService.TMenuTableCount();
            return Ok(totalMenuTableCount);
        }

    }
}
