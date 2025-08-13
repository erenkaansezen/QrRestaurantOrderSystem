using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.BusinessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DtoLayer.FeatureDto;
using Web.DtoLayer.ProductDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //Veri üzerindeki işlemler
        [HttpGet]
        public IActionResult GetProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(value);
        }

        [HttpGet("GetProductWithCategoryList")]
        public IActionResult GetProductWithCategory()
        {
            var context = new WebContext();
            var values = context.Products
                .Include(p => p.Category).Select(y => new ResultProductWithCategory
                {
                    ProductID = y.ProductID,
                    CategoryName = y.Category.CategoryName,
                    Description = y.Description,
                    ImageUrl = y.ImageUrl,
                    Price = y.Price,
                    ProductName = y.ProductName,
                    ProductStatus = y.ProductStatus,
                })
                .ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _mapper.Map<GetProductDto>(_productService.TGetById(id));
            return Ok(product);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(product);
            return Ok("Ürün başarıyla güncellendi");

        }
        [HttpGet("GetLastProduct9")]
        public IActionResult GetLastProduct9()
        {
            var products = _productService.TGetLastProduct9();
            return Ok(products);
        }

        //İstatistiksel işlemler
        [HttpGet("ProductCount")]
        public IActionResult ProductCount(int id)
        {
            return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink(int id)
        {
            return Ok(_productService.TProductCountByCategoryDrink());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger(int id)
        {
            return Ok(_productService.TProductCountByCategoryHamburger());
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg(int id)
        {
            return Ok(_productService.TProductPriceAvg());
        }
        [HttpGet("ProductNameByPriceByMax")]
        public IActionResult ProductNameByPriceByMax(int id)
        {
            return Ok(_productService.TProductNameByPriceByMax());
        }
        [HttpGet("ProductNameByPriceByMin")]
        public IActionResult ProductNameByPriceByMin(int id)
        {
            return Ok(_productService.TProductNameByPriceByMin());
        }
        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger(int id)
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }
    }
}
