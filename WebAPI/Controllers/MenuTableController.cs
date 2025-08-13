using AutoMapper;
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
        private readonly IMapper _mapper;
        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
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
            var tablelist = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll());
            return Ok(tablelist);
        }

        [HttpPost]
        public IActionResult CreateTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = false;
            var menuTable = _mapper.Map<MenuTable>(createMenuTableDto);
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
            var menuTable = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTable(int id)
        {
            var table = _mapper.Map<GetMenuTableDto>(_menuTableService.TGetById(id));
            return Ok(table);
        }
        [HttpGet("ChangeStatusTrue")]
        public IActionResult ChangeStatusTrue(int id)
        {
            _menuTableService.TChangeTableStatusTrue(id);
            return Ok("işlem başarılı");
        }
        [HttpGet("ChangeStatusFalse")]
        public IActionResult ChangeStatusFalse(int id)
        {
            _menuTableService.TChangeTableStatusFalse(id);
            return Ok("işlem başarılı");
        }

    }
}
