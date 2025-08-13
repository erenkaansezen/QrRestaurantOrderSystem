﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.BusinessLayer.Abstract;
using Web.DtoLayer.CategoryDto;
using Web.EntityLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll());
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount(int id)
        {
            return Ok(_categoryService.TCategoryCount());
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount(int id)
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount(int id)
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }


        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.Status = true;
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Kategori başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _mapper.Map<GetCategoryDto>(_categoryService.TGetById(id)); 
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategori başarıyla güncellendi");

        }
    }
}
