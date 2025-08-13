using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BasketDto;
using WebUI.Dtos.ProductDto;

namespace WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7239/api/Product/GetProductWithCategoryList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
        {
            if (createBasketDto.MenuTableID == 0)
            {
                return BadRequest("MenuTableID 0 olamaz");
            }
            

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7239/api/Basket", content);

            var client2 = _httpClientFactory.CreateClient();    
            await client2.GetAsync($"https://localhost:7239/api/MenuTable/ChangeStatusTrue?id=" + createBasketDto.MenuTableID);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest("Sepete eklenirken hata oluştu");
        }
    }
}
