using IEAMicroService.Catalog.Dtos.CategoryDtos;
using IEAMicroService.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroService.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var values = await _categoryService.GetAllCategories();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategory(createCategoryDto);
            return Ok("Kategori Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok("Kategori Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategory(updateCategoryDto);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetCategoryById(id);
            return Ok(values);
        }
    }
}
