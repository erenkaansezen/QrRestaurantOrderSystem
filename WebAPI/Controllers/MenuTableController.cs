using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.MenuTableDto;
using Web.EntityLayer.Entities;

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
        [HttpGet]
        public IActionResult GetTableList()
        {
            var values = _menuTableService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable
            {
                Name = createMenuTableDto.Name,
                Status = createMenuTableDto.Status
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Masa başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Masa başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable
            {
                MenuTableId = updateMenuTableDto.MenuTableId,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }

    }
}
