using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
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

        [HttpGet]
        public IActionResult GetProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(value);
        }

        [HttpGet("GetProductWithCategoryList")]
        public IActionResult GetProductWithCategory(int id)
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus                

            });
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün başarıyla silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductID = updateProductDto.ProductID,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus
                

            });
            return Ok("Ürün başarıyla güncellendi");

        }
    }
}
