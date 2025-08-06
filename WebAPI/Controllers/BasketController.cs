using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.BusinessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DtoLayer.BasketDto;
using Web.EntityLayer.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("GetBasketByTableNumber/{id}")]
        public IActionResult GetBasketByTableNumber(int id)
        {
            var values = _basketService.GetBasketByTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new WebContext();
            var values = context.Baskets.Include(x => x.Product)
                .Where(x => x.MenuTableId == id)
                .Select(z => new ResultBasketListWithProducts
                {
                    BasketId = z.BasketId,
                    Count = z.Count,
                    MenuTableId = z.MenuTableId,
                    Price = z.Price,
                    ProductID = z.ProductID,
                    TotalPrice = z.TotalPrice,
                    ProductName = z.Product.ProductName
                }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new WebContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableId = 4,
                Price = context.Products
                    .Where(x => x.ProductID == createBasketDto.ProductID)
                    .Select(x => x.Price).FirstOrDefault(),
                TotalPrice = 0,
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            if (value != null)
            {
                _basketService.TDelete(value);
                return Ok("Sepet başarıyla silindi");
            }
            return NotFound("Sepet bulunamadı");
        }
    }
}

